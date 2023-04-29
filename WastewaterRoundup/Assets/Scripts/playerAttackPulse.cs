using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttackPulse : MonoBehaviour {
    	  
	public int damage = 25;
	private float nextShockWaveTime = 0f;
	public float knockBackForce = 20f;
	
	//private Rigidbody2D rb2D;
	
	// Start is called before the first frame update
    void Start()
    {
		//rb2D = GetComponent<Rigidbody2D> ();
		GetComponent<CircleCollider2D>().radius = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time >= nextShockWaveTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                if (Input.GetAxis("Pulse") > 0){
                        
					//if (GameHandler.gotAbility2 >= 1) {
						//GameHandler.gotAbility2 = GameHandler.gotAbility2 - 1;
						StartCoroutine("playerShockWave");
                        nextShockWaveTime = Time.time + 2f;
					//}	
					//else {
					//Debug.Log("Not enough charge to zap!");
					//}						
                }
        } 
    }  //END OF UPDATE FUNCTION
	
	void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
                  //gameHandlerObj.playerGetHit(damage);
				  Debug.Log("We hit " + other.name);
                  Rigidbody2D pushRB = other.gameObject.GetComponent<Rigidbody2D>();
				  Vector2 moveDirectionPush = this.transform.position - other.transform.position;
				  pushRB.AddForce(moveDirectionPush.normalized * knockBackForce * - 1f, ForceMode2D.Impulse);
				  other.gameObject.GetComponent<EnemyMeleeDamage>().TakeDamage(damage);
				  StartCoroutine(EndKnockBack(pushRB));
            }
      }
	
	IEnumerator playerShockWave() {
			GetComponent<CircleCollider2D>().radius = 0.6f;
			for (int i = 0; i < 8; i++){
				GetComponent<CircleCollider2D>().radius += 0.2375f;
				Debug.Log("Radius is:" + GetComponent<CircleCollider2D>().radius );
				yield return new WaitForSeconds(0.094f);
			}
			Debug.Log("BAM!");
			stopShock();
		}
		
	IEnumerator EndKnockBack(Rigidbody2D otherRB){
              yield return new WaitForSeconds(0.2f);
              otherRB.velocity= new Vector3(0,0,0);
       }
	  
	  void stopShock () {
		GetComponent<CircleCollider2D>().radius = 0.15f;
		Debug.Log("Radius is:" + GetComponent<CircleCollider2D>().radius );
	  }
	
	
}
