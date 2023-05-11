using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttackShoot : MonoBehaviour{

      public Animator anim;
      public Transform firePoint;
      public GameObject projectilePrefab;
      public float projectileSpeed = 12f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;
	  private GameHandler m_GameHandler;
      public AudioSource soundEffect;
	  
	  private GameObject Reticle;
	  

      void Start(){
           anim = gameObject.GetComponentInChildren<Animator>();
		   Reticle = GameObject.FindWithTag("Reticle");
		   if (GameObject.FindWithTag ("GameHandler") != null) {
                  m_GameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
      }

      void Update(){
           if (GameHandler.gotAbility2 >= 1) {
				Reticle.SetActive(true);
		    }
		   else {
				Reticle.SetActive(false);
		    }
		   
		   if (Time.time >= nextAttackTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if (Input.GetAxis("Shoot") > 0){
                        
					if (GameHandler.gotAbility2 >= 1) {
						anim.SetTrigger("Zap");
						GameHandler.gotAbility2 = GameHandler.gotAbility2 - 1;
						playerFire();
                        nextAttackTime = Time.time + 1f / attackRate;
						m_GameHandler.updateStatsDisplay();
						soundEffect.Play();
					}	
					else {
					Debug.Log("Not enough charge to zap!");
					}						
                  }
            }
			
      } // END OF UPDATE FUNCTION

      void playerFire(){
            Vector2 fwd = (firePoint.position - this.transform.position).normalized;
			//Vector2 fwd = (firePoint.position - this.transform.position);
            GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(fwd * projectileSpeed, ForceMode2D.Impulse);
      }
	  
} 
