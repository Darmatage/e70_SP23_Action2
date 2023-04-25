using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableClump : MonoBehaviour
{
	public PlayerMove_Rotate PM;
	private Renderer rend;
	public GameObject clumpLoot1;
	public GameObject clumpLoot2;
	public GameObject clumpLoot3;
	public GameObject clumpLoot4;
	
	public int maxHealth = 40;
    public int currentHealth;
	
	private GameHandler gameHandler;
	
	
    // Start is called before the first frame update
    void Start()
    {
		rend = GetComponentInChildren<Renderer> ();
		
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			PM = GameObject.FindWithTag ("Player").GetComponent<PlayerMove_Rotate> ();
        }
		
		if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
		currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    } // END OF UPDATE FUNCTION
	
	public void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Player" && PM.isDashing == true) {
			Die();
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
			if (lootRoll == 1) {
			  Instantiate (clumpLoot1, transform.position, Quaternion.identity);
              //anim.SetTrigger ("KO");
              GetComponent<Collider2D>().enabled = false;
              StartCoroutine(Death());
			}
			else if (lootRoll == 2) {
			  Instantiate (clumpLoot2, transform.position, Quaternion.identity);
              //anim.SetTrigger ("KO");
              GetComponent<Collider2D>().enabled = false;
              StartCoroutine(Death());
			}
			else if (lootRoll == 3) {
				Instantiate (clumpLoot3, transform.position, Quaternion.identity);
              //anim.SetTrigger ("KO");
              GetComponent<Collider2D>().enabled = false;
              StartCoroutine(Death());
			}
			else if (lootRoll == 4) {
				Instantiate (clumpLoot4, transform.position, Quaternion.identity);
              //anim.SetTrigger ("KO");
              GetComponent<Collider2D>().enabled = false;
              StartCoroutine(Death());
			}
       }

       IEnumerator Death(){
              yield return new WaitForSeconds(0.25f);
              Debug.Log("Clump Smashed!");
              Destroy(gameObject);
			  gameHandler.updateStatsDisplay();
       }
	   
	   IEnumerator ResetColor(){
              yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }
	
}
