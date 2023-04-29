using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttackPulse : MonoBehaviour {
    	  
	public int damage = 25;
	private float nextShockWaveTime = 0f;
	
	// Start is called before the first frame update
    void Start()
    {
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
                        nextShockWaveTime = Time.time + 3f;
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
                  other.gameObject.GetComponent<EnemyMeleeDamage>().TakeDamage(damage);
            }
      }
	
	IEnumerator playerShockWave() {
			GetComponent<CircleCollider2D>().radius = 0.6f;
			for (int i = 0; i < 8; i++){
				GetComponent<CircleCollider2D>().radius += 0.2375f;
				Debug.Log("Radius is:" + GetComponent<CircleCollider2D>().radius );
				yield return new WaitForSeconds(0.1875f);
			}
			Debug.Log("BAM!");
			stopShock();
		}
	  
	  void stopShock () {
		GetComponent<CircleCollider2D>().radius = 0.15f;
		Debug.Log("Radius is:" + GetComponent<CircleCollider2D>().radius );
	  }
	
	
}
