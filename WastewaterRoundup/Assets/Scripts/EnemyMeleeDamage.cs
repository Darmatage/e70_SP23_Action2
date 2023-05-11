using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour {
       public Renderer rend;
       public Animator anim;
       public GameObject enemyLoot1;
	   public GameObject enemyLoot2;
	   public GameObject enemyLoot3;
	   public GameObject enemyLoot4;
       public int maxHealth = 100;
       public int currentHealth;
	   
	   private GameHandler gameHandler;

       void Start(){
              rend = GetComponentInChildren<Renderer>();
              anim = GetComponentInChildren<Animator>();
              currentHealth = maxHealth;
			  
			  if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
       }

       public void TakeDamage(int damage){
              currentHealth -= damage;
              rend.material.color = new Color(2.4f, 0.9f, 0.9f, 1f);
              StartCoroutine(ResetColor());
              //anim.SetTrigger ("getHurt");
              if (currentHealth <= 0){
                     Die();
              }
       }

       void Die(){
            int lootRoll = Random.Range(1, 5);
			anim.SetTrigger("Death");
			if (lootRoll == 1) {
				Instantiate (enemyLoot1, transform.position, Quaternion.identity);
				//anim.SetTrigger ("KO");
				GetComponent<Collider2D>().enabled = false;
				StartCoroutine(Death());
			}
			if (lootRoll == 2) {
				Instantiate (enemyLoot2, transform.position, Quaternion.identity);
				//anim.SetTrigger ("KO");
				GetComponent<Collider2D>().enabled = false;
				StartCoroutine(Death());
			}
			if (lootRoll == 3) {
				Instantiate (enemyLoot3, transform.position, Quaternion.identity);
				//anim.SetTrigger ("KO");
				GetComponent<Collider2D>().enabled = false;
				StartCoroutine(Death());
			}
			if (lootRoll == 4) {
				Instantiate (enemyLoot4, transform.position, Quaternion.identity);
				//anim.SetTrigger ("KO");
				GetComponent<Collider2D>().enabled = false;
				StartCoroutine(Death());
			}
       }

       IEnumerator Death(){
              anim.SetTrigger("death");
              yield return new WaitForSeconds(2f);
              Debug.Log("You Killed a baddie. You deserve loot!");
              Destroy(gameObject);
			  gameHandler.updateStatsDisplay();
       }

       IEnumerator ResetColor(){
              yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }
}

