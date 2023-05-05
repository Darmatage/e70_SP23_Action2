using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour{

      public Animator anim;
      public Transform attackPt;
      public float attackRange = 0.5f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;
	  public float knockBackForce = 8f;
      public int attackDamage = 40;
      public LayerMask enemyLayers;
	  public AudioSource soundEffect;
	  private Vector2 moveDirection;

      void Start(){
           anim = gameObject.GetComponentInChildren<Animator>();
      }

      void Update(){
           
		   float horizontalInput = Input.GetAxis ("Horizontal");
           float verticalInput = Input.GetAxis ("Vertical");
		   Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
		   
		   if (Time.time >= nextAttackTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if (Input.GetAxis("Attack") > 0){
                        //Attack();
						soundEffect.Play();
                        nextAttackTime = Time.time + 1f / attackRate;
                  }
            }
      }

      /*void Attack(){
            anim.SetTrigger ("Melee");
            Collider2D[] hitEnemies = Physics2D.OverlapCapsuleAll(attackPt.position, attackRange, moveDirection, 90, enemyLayers);
           
            foreach(Collider2D enemy in hitEnemies){
                  Debug.Log("We hit " + enemy.name);
                  enemy.GetComponent<EnemyMeleeDamage>().TakeDamage(attackDamage);
				  Rigidbody2D pushRB = enemy.GetComponent<Rigidbody2D>();
				  Vector2 moveDirectionPush = this.transform.position - enemy.transform.position;
				  pushRB.AddForce(moveDirectionPush.normalized * knockBackForce * - 1f, ForceMode2D.Impulse);
				  StartCoroutine(EndKnockBack(pushRB));
            }
      }*/

      //NOTE: to help see the attack sphere in editor:
      void OnDrawGizmosSelected(){
           if (attackPt == null) {return;}
            Gizmos.DrawWireSphere(attackPt.position, attackRange);
      }
	  
	  IEnumerator EndKnockBack(Rigidbody2D otherRB){
              yield return new WaitForSeconds(0.4f);
              otherRB.velocity= new Vector3(0,0,0);
    }
}
