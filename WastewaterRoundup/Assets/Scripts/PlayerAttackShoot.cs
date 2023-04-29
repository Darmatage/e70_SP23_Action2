using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttackShoot : MonoBehaviour{

      //public Animator animator;
      public Transform firePoint;
      public GameObject projectilePrefab;
      public float projectileSpeed = 10f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;
	  private GameHandler m_GameHandler;
	  

      void Start(){
           //animator = gameObject.GetComponentInChildren<Animator>();
		   if (GameObject.FindWithTag ("GameHandler") != null) {
                  m_GameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
      }

      void Update(){
           if (Time.time >= nextAttackTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if (Input.GetAxis("Shoot") > 0){
                        
					if (GameHandler.gotAbility2 >= 1) {
						GameHandler.gotAbility2 = GameHandler.gotAbility2 - 1;
						playerFire();
                        nextAttackTime = Time.time + 1f / attackRate;
						m_GameHandler.updateStatsDisplay();
					}	
					else {
					Debug.Log("Not enough charge to zap!");
					}						
                  }
            }
			
      } // END OF UPDATE FUNCTION

      void playerFire(){
            //animator.SetTrigger ("Fire");
            Vector2 fwd = (firePoint.position - this.transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(fwd * projectileSpeed, ForceMode2D.Impulse);
      }
	  
} 
