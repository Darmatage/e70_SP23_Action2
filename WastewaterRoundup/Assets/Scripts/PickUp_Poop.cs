using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Poop : MonoBehaviour{

      //private Animator anim;
	  private GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
      public bool isBlue = true;
      public bool isRed = false;
      public bool isWhite = false;
      public bool isGreen = false;
	  
	  private bool alreadyGrabbed = false;
	  
	  public GameObject art;
	  
	  public int healthBoost = 1;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (alreadyGrabbed == false) {
				if (other.gameObject.tag == "Player"){
					  alreadyGrabbed = true;
					  GetComponent<Collider2D>().enabled = false;
					  GetComponentInChildren<SpriteRenderer>().enabled = false;
					  //anim = other.GetComponentInChildren<Animator>;
					  other.GetComponentInChildren<Animator>().SetTrigger("Chomp");
					  Debug.Log("Pickup found!");
					  
					  //animator.SetTrigger("Chomp");
					  GetComponent<AudioSource>().Play();
					  StartCoroutine(DestroyThis());
					  
					  if (isBlue == true) {
							GameHandler.gotBlueTokens += 1;
							gameHandler.playerGetHit(healthBoost * -1);
							//playerPowerupVFX.powerup();
							Debug.Log("It's blue!");
					  }
					  
					  if (isRed == true) {
							GameHandler.gotRedTokens += 1;
							gameHandler.playerGetHit(healthBoost * -1);
							//playerPowerupVFX.powerup();
							Debug.Log("It's red!");
					  }
					  
					  if (isWhite == true) {
							GameHandler.gotWhiteTokens += 1;
							gameHandler.playerGetHit(healthBoost * -1);
							//playerPowerupVFX.powerup();
							Debug.Log("It's white!");
					  }
					  
					  if (isGreen == true) {
							GameHandler.gotGreenTokens += 1;
							gameHandler.playerGetHit(healthBoost * -1);
							//playerPowerupVFX.powerup();
							Debug.Log("It's green!");
					  }

				}
			}
        }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
      }

}
