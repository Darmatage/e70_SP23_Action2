using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMoveHit : MonoBehaviour {

       private Animator anim;
       private Rigidbody2D rb2D;
       public float speed = 4f;
       private Transform target;
       public int damage = 10;
	   
       private GameHandler gameHandler;

       public float attackRange = 10;
       public bool isAttacking = false;
       private float scaleX;
	   
	   public float knockBackForce = 20f; 
	   
	   public PlayerMove_Rotate PM;
	   public EnemyMeleeDamage EMD;

       void Start () {
              anim = GetComponentInChildren<Animator> ();
              rb2D = GetComponent<Rigidbody2D> ();
              scaleX = gameObject.transform.localScale.x;
			
			EMD = this.GetComponent<EnemyMeleeDamage> ();
              if (GameObject.FindGameObjectWithTag ("Player") != null) {
                     target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
					 PM = GameObject.FindWithTag ("Player").GetComponent<PlayerMove_Rotate> ();
              }

              if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
       }

       void Update () {
              float DistToPlayer = Vector3.Distance(transform.position, target.position);

              if ((target != null) && (DistToPlayer <= attackRange)){
                     transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
                    anim.SetBool("chasing", true);
                    //flip enemy to face player direction. Wrong direction? Swap the * -1.
                    if (target.position.x > gameObject.transform.position.x){
                                   gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
                    } else {
                                    gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
                    }
              }
               else { anim.SetBool("chasing", false);}
       }

       public void OnCollisionEnter2D(Collision2D other){
            if (EMD.isDying == false) { 
			  if (other.gameObject.tag == "Player") {
                     isAttacking = true;
                     // anim.SetBool("attack", true);
                     anim.SetTrigger("attack");
                    
                     //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
                     //StartCoroutine(HitEnemy());

			//This method adds force to the player, pushing them back without teleporting (choose above or below).
					if (PM.isDashing == false) {
						Rigidbody2D pushRB = other.gameObject.GetComponent<Rigidbody2D>();
						Vector2 moveDirectionPush = rb2D.transform.position - other.transform.position;
						if (other != null) { 
							gameHandler.playerGetHit(damage);
						}
						if (other != null) {
							pushRB.AddForce(moveDirectionPush.normalized * knockBackForce * - 1f, ForceMode2D.Impulse);
						}
						StartCoroutine(EndKnockBack(pushRB));
					}
                }
			}
        } 

       public void OnCollisionExit2D(Collision2D other){
              if (other.gameObject.tag == "Player") {
                     isAttacking = false;
                     // anim.SetBool("attack", false);
              }
       }
	   
	   IEnumerator EndKnockBack(Rigidbody2D otherRB){
              yield return new WaitForSeconds(0.2f);
              otherRB.velocity= new Vector3(0,0,0);
       } 

       //DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, attackRange);
       }
}