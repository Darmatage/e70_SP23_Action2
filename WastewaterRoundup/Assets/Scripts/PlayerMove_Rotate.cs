using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove_Rotate :  MonoBehaviour {

	  private Animator anim;

      public float playerSuckStrength = 1.5f;
	  public float moveSpeed = 5f;
	  public float startSpeed = 5f;
      public float rotationSpeed = 720f;
	  private float nextDashTime = 0f;
	  private float nextO2HitTime = 0f;
	  private float nextBreathTime = 0f;
	  private float nextPlatformTime = 0f;
	  public float suckRadius = 10f;
	  public int breathTime = 1;            // the time between each loss of oxygen
	  public int breathCost = 2;			// how much O2 the player will lose each second
	  public int platformOxygen = 17;		// how much O2 the player will gain each second while near O2 platforms
	  public int oxygenDamage = 20;			//how much damage the player will take each second while out of O2
	  public int platformRange = 6;		// how close the player must be to a platform to receive O2 from it
	  private bool isMoving = false;		//tracks whether player is moving
	  public AudioSource dashSound;
	  public AudioSource breatheSound;
	  public AudioSource suckSound;
	  
	  //private bool foundPlatforms = false;
	  
	  public bool isDashing = false;		//tracks whether the player is dashing
	  
	  private GameHandler GameHandler;

      void Start() {
			anim = GetComponentInChildren<Animator>();
			if (GameObject.FindWithTag ("GameHandler") != null) {
                GameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
            }
			  
		  
	    }
	  
	  void Update(){
          
			GameObject[] AllPlatforms = GameObject.FindGameObjectsWithTag("O2_Platform");
			
			float horizontalInput = Input.GetAxis ("Horizontal");
            float verticalInput = Input.GetAxis ("Vertical");
            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
            float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
            moveDirection.Normalize();

            transform.Translate(moveDirection * moveSpeed * inputMagnitude * Time.deltaTime, Space.World);
			


            if (moveDirection != Vector2.zero) {
                  Quaternion toRotation = Quaternion.LookRotation (Vector3.forward, moveDirection);
                  transform.rotation = Quaternion.RotateTowards (transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
				  isMoving = true;
				  anim.SetBool("Swim", true);
			}
			else {
				isMoving = false;
				anim.SetBool("Swim", false);
			}
			
			if (isMoving == true) {						// if the player is moving, then the dash ability becomes usable
				if (Time.time >= nextDashTime){			// however, the game will not allow the player to dash more than once per second.
					if (Input.GetAxis("Dash") > 0) {
						if (GameHandler.gotAbility1 >= 1) {
							GameHandler.gotAbility1 = GameHandler.gotAbility1 - 1;
							GameHandler.updateStatsDisplay();
							dashSound.Play();
							anim.SetBool("Dash", true);
							speedBoost(4f, 0.25f);					// the true function of the dash: player movement is multiplied by 4 for .25 seconds.
							nextDashTime = Time.time + 1f;
							Debug.Log("You Dashed!");
						}
						else {
							Debug.Log("Not enough energy to Dash!");
						}
					}
				}
			}
			if (GameHandler.playerOxygen <= 0) {					//this checks the gamehandler's oxygen value, to determine whether or not they should be taking damage from O2 deprivation
				if (Time.time >= nextO2HitTime) {					// like the Dash ability, the game will only allow the player to take O2 damage once per second.
					GameHandler.playerGetHit(oxygenDamage);
					GameHandler.updateStatsDisplay();
					nextO2HitTime = Time.time + 1f;
				}
			}
			
				if (Time.time >= nextBreathTime) {					//  the game will only allow the player to lose O2 once per second.
					GameHandler.playerOxygen = GameHandler.playerOxygen - breathCost;
					GameHandler.updateStatsDisplay();
					nextBreathTime = Time.time + breathTime;
				}
			
			
			for(int i = 0; i < AllPlatforms.Length; i++) {			//now, we need a way to check the distance from the nearest O2 platform. so we look at the list we made when we started the level, and check the distance to each one.
         
                if(Vector2.Distance(this.transform.position, AllPlatforms[i].transform.position) <= platformRange) {
					if (Time.time >= nextPlatformTime) {					//  the game will only allow the player to gain O2 once per second.
					GameHandler.playerOxygen = GameHandler.playerOxygen + platformOxygen;
					breatheSound.Play();
					GameHandler.updateStatsDisplay();
					nextPlatformTime = Time.time + 1f;
					}
                }
			}
			
			if (GameHandler.playerOxygen >= 101) {
				GameHandler.playerOxygen = GameHandler.StartPlayerOxygen;
			}

			if (Input.GetKeyDown(KeyCode.F)) {
                if (GameHandler.gotAbility4 >= 1) {
					GameHandler.gotAbility4 -= 1;
					Debug.Log("Doing the Big Suck");
					suckSound.Play();
					BigSuck();
				}
            }
			
		} // END OF UPDATE FUNCTION
	  
	  public void speedBoost(float speedBoost, float speedLength){
            isDashing = true;
			moveSpeed = moveSpeed * speedBoost;
            StartCoroutine(normalSpeed(speedLength));
      }

      IEnumerator normalSpeed(float speedLength){
            yield return new WaitForSeconds(speedLength);
            moveSpeed = startSpeed;       //NOTE: returns this stat to normal
			isDashing = false;
			anim.SetBool("Dash", false);
      }


	void BigSuck(){
			Debug.Log("Collecting the Poop!");
			GameObject[] AllPickups = GameObject.FindGameObjectsWithTag("Pickups");

			foreach (GameObject pickup in AllPickups) {
				if(Vector2.Distance(this.transform.position, pickup.transform.position) <= suckRadius) {
					Rigidbody2D pushRB = pickup.gameObject.GetComponent<Rigidbody2D>();
					Vector2 moveDirectionPush = pickup.transform.position - this.transform.position;
					pushRB.AddForce(moveDirectionPush * playerSuckStrength * - 1f, ForceMode2D.Impulse);
					StartCoroutine(EndKnockBack(pushRB));
				}
			}
	}

	IEnumerator EndKnockBack(Rigidbody2D otherRB){
              yield return new WaitForSeconds(1.5f);
			  otherRB.velocity = new Vector3(0,0,0);
    }


} // END OF MONOBEHAVIOR


