using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove_Rotate :  MonoBehaviour {

	//private Animator anim;

      public float moveSpeed = 5f;
	  public float startSpeed = 5f;
      public float rotationSpeed = 720f;
	  private float nextDashTime = 0f;
	  private float nextO2HitTime = 0f;
	  private float nextBreathTime = 0f;
	  private float nextPlatformTime = 0f;
	  public float suckRadius = 8f;
	  public int breathTime = 1;            // the time between each loss of oxygen
	  public int breathCost = 2;			// how much O2 the player will lose each second
	  public int platformOxygen = 17;		// how much O2 the player will gain each second while near O2 platforms
	  public int oxygenDamage = 20;			//how much damage the player will take each second while out of O2
	  public int platformRange = 6;		// how close the player must be to a platform to receive O2 from it
	  private bool isMoving = false;		//tracks whether player is moving
	  //private bool foundPlatforms = false;
	  
	  public bool isDashing = false;		//tracks whether the player is dashing
	  
	  private GameHandler GameHandler;

      void Start() {
			//anim = GetComponentInChilderen<Animator>();
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
				  //anim.SetBool("move", true);
			}
			else {
				isMoving = false;
				//anim.SetBool("move", false);
			}
			
			if (isMoving == true) {						// if the player is moving, then the dash ability becomes usable
				if (Time.time >= nextDashTime){			// however, the game will not allow the player to dash more than once per second.
					if (Input.GetAxis("Dash") > 0) {
						if (GameHandler.gotAbility1 >= 1) {
							GameHandler.gotAbility1 = GameHandler.gotAbility1 - 1;
							GameHandler.updateStatsDisplay();
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
					GameHandler.updateStatsDisplay();
					nextPlatformTime = Time.time + 1f;
					}
                }
			}
			
			if (GameHandler.playerOxygen >= 101) {
				GameHandler.playerOxygen = GameHandler.StartPlayerOxygen;
			}

			 //if (Input.GetKeyDown(KeyCode.B)) {
                  // Debug.Log("Doing the Big Suck");
                  //BigSuck();
            //}
			
		} // END OF UPDATE FUNCTION
	  
	  public void speedBoost(float speedBoost, float speedLength){
            isDashing = true;
			//anim.SetBool("dash", true);
			moveSpeed = moveSpeed * speedBoost;
            StartCoroutine(normalSpeed(speedLength));
      }

      IEnumerator normalSpeed(float speedLength){
            yield return new WaitForSeconds(speedLength);
            moveSpeed = startSpeed;       //NOTE: returns this stat to normal
			isDashing = false;
			//anim.SetBool("dash", false);
      }

	public void OnTriggerEnter2D(Collider2D other){
		if ((other.gameObject.tag=="PickUpBlue")||
		(other.gameObject.tag=="PickUpRed")||
		(other.gameObject.tag=="PickUpWhite")||
		(other.gameObject.tag=="PickUpGreen")){
			PlayerChomp();
		}
	}
	
	public void PlayerChomp(){
		//anim.SetTrigger("chomp");
	}


	/*void BigSuck(){
        Debug.Log("Collecting the Poop!");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, suckRadius);
      //   string collidersString = string.Join(", ", (object[])colliders);
      //   Debug.Log(collidersString);
      // Debug.Log("Number of colliders: " + colliders.Length);

        foreach (Collider2D collider in colliders) {
            string pickupName = collider.name;
            Debug.Log(pickupName);
            if (collider.gameObject.CompareTag("PickUpGreen")) {
                GameHandler.gotGreenTokens = GameHandler.gotGreenTokens + 1;
                Debug.Log("Green" + GameHandler.gotGreenTokens);
                Destroy(collider.gameObject);
				GameHandler.updateStatsDisplay();
            } else if (collider.gameObject.CompareTag("PickUpBlue")) {
                GameHandler.gotBlueTokens = GameHandler.gotBlueTokens + 1;
                Destroy(collider.gameObject);
				GameHandler.updateStatsDisplay();				
            } else if (collider.gameObject.CompareTag("PickUpRed")) {
                GameHandler.gotRedTokens = GameHandler.gotRedTokens + 1;
                Destroy(collider.gameObject);
				GameHandler.updateStatsDisplay();
            } else if (collider.gameObject.CompareTag("PickUpWhite")) {
                GameHandler.gotWhiteTokens = GameHandler.gotWhiteTokens + 1;
                Destroy(collider.gameObject); 
				GameHandler.updateStatsDisplay();
            }

        }
    }*/
	
	/*void BigSuck(){
        Debug.Log("Collecting the Poop!");
        GameObject[] nearbyPickups = Physics2D.OverlapCircleAll(transform.position, suckRadius);

        foreach (GameObject pickup in nearbyPickups) {
           if (pickup.gameObject.layer == LayerMask.NameToLayer("Pickups")) { 
            
		    }
        }
    } */

} // END OF MONOBEHAVIOR