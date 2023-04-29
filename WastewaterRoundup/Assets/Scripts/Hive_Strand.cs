using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive_Strand : MonoBehaviour{

	public int numHits = 0;
	public int maxHits = 3;
	
	public float knockBackForce = 10f;
	private float nextStrandHitTime = 0f;

	public Hive_Handler hiveHandler;

	public Renderer rend;
	//public Sprite strand1;
	//public Sprite strand2;
	//public Sprite strand3;
	//public Sprite strand4;

    void Start(){
        rend = GetComponentInChildren<Renderer>();
		//rend.Sprite = strand1;
    }


    public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			if (Time.time >= nextStrandHitTime){
				HitStrand();
				nextStrandHitTime = Time.time + 1.5f;
				Debug.Log("Player bit " + this.name);
                Rigidbody2D pushRB = other.gameObject.GetComponent<Rigidbody2D>();
				Vector2 moveDirectionPush = this.transform.position - other.transform.position;
				pushRB.AddForce(moveDirectionPush.normalized * knockBackForce * - 1f, ForceMode2D.Impulse);
				StartCoroutine(EndKnockBack(pushRB));
			}	
			
			/*else {
				hiveHandler.StrandDeath();
				Destroy(gameObject);
			}*/
			
		}
        
    }
	
	public void HitStrand(){
		numHits += 1;
		//if (numHits == 1){rend.sprite = strand2;}
		//else if (numHits == 2){rend.sprite = strand3;}
		//else {rend.sprite = strand4;}
		
		//make strand thinner
		float newX = transform.localScale.x * 0.75f;
		float sameY = transform.localScale.y;
		transform.localScale = new Vector2(newX, sameY);
		
		//change the color of the strand
		rend.material.color = new Color(2.4f, 0.9f, 0.9f, 1f);
        StartCoroutine(ResetColor());
		if (numHits >= maxHits){
			hiveHandler.StrandDeath();
			Destroy(gameObject);	
		}
		
	}
	
	IEnumerator ResetColor(){
		yield return new WaitForSeconds(0.5f);
		rend.material.color = Color.white;
		
	}
	
	IEnumerator EndKnockBack(Rigidbody2D otherRB){
              yield return new WaitForSeconds(0.2f);
              otherRB.velocity= new Vector3(0,0,0);
    }
	
	
}
