using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp_Poop : MonoBehaviour{

      private GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
      public bool isBlue = true;
      public bool isRed = false;
      public bool isWhite = false;
      public bool isGreen = false;
	  
	  public GameObject art;
	  
	  public int healthBoost = 1;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<Collider2D>().enabled = false;
				  GetComponentInChildren<SpriteRenderer>().enabled = false;
                  GetComponent<AudioSource>().Play();
                  StartCoroutine(DestroyThis());
				  
                  if (isBlue == true) {
						GameHandler.gotBlueTokens += 1;
                        gameHandler.playerGetHit(healthBoost * -1);
                        //playerPowerupVFX.powerup();
                  }
				  
                  if (isRed == true) {
						GameHandler.gotRedTokens += 1;
                        gameHandler.playerGetHit(healthBoost * -1);
                        //playerPowerupVFX.powerup();
                  }
				  
                  if (isWhite == true) {
						GameHandler.gotWhiteTokens += 1;
                        gameHandler.playerGetHit(healthBoost * -1);
                        //playerPowerupVFX.powerup();
                  }
				  
                  if (isGreen == true) {
						GameHandler.gotGreenTokens += 1;
                        gameHandler.playerGetHit(healthBoost * -1);
                        //playerPowerupVFX.powerup();
                  }

            }
      }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
      }

}
