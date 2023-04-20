using UnityEngine;
using System;
using System.Collections;

public class PlayerMove_Rotate :  MonoBehaviour {

      public float moveSpeed = 5f;
	  public float startSpeed = 5f;
      public float rotationSpeed = 720f;
	  
	  private GameHandler GameHandler;

      void Start() {
		  
			if (GameObject.FindWithTag ("GameHandler") != null) {
                  GameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
		  
	    }
	  
	  void Update(){
            float horizontalInput = Input.GetAxis ("Horizontal");
            float verticalInput = Input.GetAxis ("Vertical");
            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
            float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
            moveDirection.Normalize();

            transform.Translate(moveDirection * moveSpeed * inputMagnitude * Time.deltaTime, Space.World);
			


            if (moveDirection != Vector2.zero) {
                  Quaternion toRotation = Quaternion.LookRotation (Vector3.forward, moveDirection);
                  transform.rotation = Quaternion.RotateTowards (transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
			
			if (Input.GetAxis("Dash") > 0) {
				if (GameHandler.gotAbility1 >= 1) {
					GameHandler.gotAbility1 = GameHandler.gotAbility1 - 1;
					GameHandler.updateStatsDisplay();
					speedBoost(4f, 0.25f);
				}
				else {
					Debug.Log("Not enough energy to Dash!");
				}
			}
      }
	  
	  public void speedBoost(float speedBoost, float speedLength){
            moveSpeed = moveSpeed * speedBoost;
            StartCoroutine(normalSpeed(speedLength));
      }

      IEnumerator normalSpeed(float speedLength){
            yield return new WaitForSeconds(speedLength);
            moveSpeed = startSpeed;       //NOTE: returns this stat to normal
      }

}
