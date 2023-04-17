using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player_Follower : MonoBehaviour {
       //this script offers basic flocking behavior for friendly NPCs to follow the player
       //commented-out are functions for followers to help attack enemies if the player attacks

       //private Animator anim;

//Follow Player
       private GameObject player;
       private Vector2 playerPos;
       private float distToPlayer;
       public float startFollowDistance; //Follow Player when further than this distance
       public float followDistance; //Stop moving towards player when at this distance
       public float moveSpeed;
       public float topSpeed = 10f;
       private float scaleX;
       //public Vector2 offsetFollow;

//Follow Player vs Attack Enemies
       public bool followPlayer = true;
       /*
        public bool attackEnemy = false; // target enemy within range of player when player attacks
        public bool isAttacking = false; // attack a targeted enemy
        public float peacefullTime = 4f;
       */

//Attack variables
       /*
        public LayerMask enemyLayers;
        public GameObject enemyTarget;
        private Vector2 enemyPos;
        private float distToEnemy;
        private float timeBtwShots;
        public float startTimeBtwShots = 2;
        public GameObject projectile;
        public float attackRange = 10f;
       */

       void Start(){
              //anim = gameObject.GetComponentInChildren<Animator>();
              player = GameObject.FindWithTag("Player");
              followDistance = Random.Range(0.5f, 1.5f);
              startFollowDistance = followDistance + 1f;
              moveSpeed = Random.Range((topSpeed * 0.7f), topSpeed);
              scaleX = gameObject.transform.localScale.x;
       }

       void Update(){
              //listen for player attacking an enemy, enter combat until player stops attacking
              /*
              if ((Input.GetAxis("AttackFire") > 0) || (Input.GetAxis("AttackMelee") > 0)){
                     followPlayer = false;
                     attackEnemy = true;
                     StartCoroutine(StopAttackingEnemies());
                     FindTheEnemy();
               }
               */
        }

        void FixedUpdate(){
                //FOLLOW PLAYER
               if ((followPlayer) && (player != null)){
                      playerPos = player.transform.position;
                      distToPlayer = Vector2.Distance(transform.position, playerPos);

                      //Retreat from Player
                      if (distToPlayer <= followDistance){
                                transform.position = Vector2.MoveTowards (transform.position, playerPos, -moveSpeed * Time.deltaTime);
                                //anim.SetBool("Walk", true);
                      }

                      // Stop following Player
                      if ((distToPlayer > followDistance) && (distToPlayer < startFollowDistance)){
                                transform.position = this.transform.position;
                                //anim.SetBool("Walk", false);
                      }

                      // Follow Player
                      else if (distToPlayer >= startFollowDistance){
                                transform.position = Vector2.MoveTowards (transform.position, playerPos, moveSpeed * Time.deltaTime);
                                //anim.SetBool("Walk", true);
                      }

                      // Turn follower toward player (good for bipedal characters)
                      /*
                       if (player.transform.position.x > gameObject.transform.position.x){
                                gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
                        } else {
                                gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
                        }
                        */

                        // Rotate to face player (good for swimming / flying followers)
                        Vector2 direction = (playerPos - (Vector2)transform.position).normalized;
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        float offset = 90f;
                        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
              }


                //FOLLOW ENEMY
                /*
                if ((attackEnemy) && (enemyTarget != null)){
                        enemyPos = enemyTarget.transform.position;
                        distToEnemy = Vector2.Distance(transform.position, enemyPos);

                        // Retreat from enemy
                        if (distToEnemy <= followDistance){
                                transform.position = Vector2.MoveTowards (transform.position, enemyPos, -moveSpeed * Time.deltaTime);
                                anim.SetBool("Walk", true);
                        }

                        // Stop following enemy
                        if ((distToEnemy > followDistance) && (distToEnemy < startFollowDistance)){
                                transform.position = this.transform.position;
                                anim.SetBool("Walk", false);
                        }

                        // Follow enemy
                        else if ((distToEnemy >= startFollowDistance)){
                                transform.position = Vector2.MoveTowards (transform.position, enemyPos, moveSpeed * Time.deltaTime);
                                anim.SetBool("Walk", true);
                        }

                        // Turn buddy toward enemy
                        if (enemyTarget.transform.position.x > gameObject.transform.position.x){
                                gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
                        } else {
                                gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
                        }
                }
                */

                //Timer for shooting projectiles
                /*
                if ((attackEnemy==true)&&(enemyTarget !=null) && (distToEnemy > followDistance) && (distToEnemy < startFollowDistance)){
                        if (timeBtwShots <= 0) {
                                isAttacking = true;
                                anim.SetBool("Attack", true);

                                GameObject myProjectile = Instantiate (projectile, transform.position, Quaternion.identity);
                                myProjectile.GetComponent ().attackPlayer = false;
                                myProjectile.GetComponent ().enemyTrans = enemyTarget.transform;

                                timeBtwShots = startTimeBtwShots;
                        } else {
                                timeBtwShots -= Time.deltaTime;
                                isAttacking = false;
                                anim.SetBool("Attack", true);
                        }
                }
                */

        //end bracket of FixedUpdate:
        }


        /*
        void FindTheEnemy(){
                //animator.SetTrigger ("Melee");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerPos, attackRange, enemyLayers);

                foreach(Collider2D enemy in hitEnemies){
                        Debug.Log("Buddy targeting " + enemy.name);
                        enemyTarget = enemy.gameObject;
                        //enemy.GetComponent ().TakeDamage(attackDamage);
                }
        }
        */

        /*
        IEnumerator StopAttackingEnemies(){
                yield return new WaitForSeconds(peacefullTime);
                followPlayer = true;
                attackEnemy = false;
        }
        */

        // DISPLAY the range of enemy's attack when selected in the Editor
        void OnDrawGizmos(){
                Gizmos.DrawWireSphere(transform.position, followDistance);
        }

} 