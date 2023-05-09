using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttackPulse : MonoBehaviour {
    	  
	private Animator anim;
	public int damage = 25;
	private float nextShockWaveTime = 0f;
	private float newScale = 1f;
	public float knockBackForce = 20f;
	public GameObject pulseEffectAnim;
	private bool isPulsing = false;
	private bool strandAlready = false;
	public AudioSource soundEffect;
	//private Rigidbody2D rb2D;
	
	// Start is called before the first frame update
    void Start()
    {
		anim = GetComponentInChildren<Animator>();
		//rb2D = GetComponent<Rigidbody2D> ();
		GetComponent<CircleCollider2D>().radius = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time >= nextShockWaveTime){
                  //if (Input.GetKeyDown(KeyCode.Space))
                if (Input.GetAxis("Pulse") > 0){
                        
					if (GameHandler.gotAbility3 >= 1) {
						GameHandler.gotAbility3 = GameHandler.gotAbility3 - 1;
						isPulsing = true;
						anim.SetTrigger("Pulse");
						strandAlready = false;
						GameObject animEffect = Instantiate (pulseEffectAnim, transform.position, Quaternion.identity);
						StartCoroutine(selfDestructHit(animEffect));
						StartCoroutine("playerShockWave");
						soundEffect.Play();
                        nextShockWaveTime = Time.time + 2f;
						//Debug.Log("Starting Pulse.");
					//}	
					//else {
					//Debug.Log("Not enough charge to zap!");
					}						
                }
        } 
    }  //END OF UPDATE FUNCTION
	
	void OnTriggerEnter2D(Collider2D other){
        if (isPulsing==true){    
			if ((other.gameObject.layer == LayerMask.NameToLayer("Enemies")) || (other.gameObject.layer == LayerMask.NameToLayer("Pickups")))  {
                  //gameHandlerObj.playerGetHit(damage);
				  Debug.Log("We hit " + other.name);
                  Rigidbody2D pushRB = other.gameObject.GetComponent<Rigidbody2D>();
				  Vector2 moveDirectionPush = this.transform.position - other.transform.position;
				  pushRB.AddForce(moveDirectionPush.normalized * knockBackForce * - 1f, ForceMode2D.Impulse);
				  if (other != null) {
						if (other.gameObject.tag != "Pickups") {
							other.gameObject.GetComponent<EnemyMeleeDamage>().TakeDamage(damage);
						}
						StartCoroutine(EndKnockBack(pushRB));
				    }
            }
			if (other.gameObject.layer == LayerMask.NameToLayer("Clumps")) {
				  Debug.Log("We hit " + other.name);
                  other.gameObject.GetComponent<BreakableClump>().TakeDamage(damage);
            }
			if (other.gameObject.layer == LayerMask.NameToLayer("strand")) {
				if (strandAlready == false) {
				  Debug.Log("We hit " + other.name);
				  strandAlready = true;
                  other.gameObject.GetComponent<Hive_Strand>().HitStrand();
				}
            }
		}
    }
	
	/*IEnumerator playerShockWave() {
			GetComponent<CircleCollider2D>().radius = 0.6f;
			for (int i = 0; i < 8; i++){
				GetComponent<CircleCollider2D>().radius += 0.2375f;
				Debug.Log("Radius is:" + GetComponent<CircleCollider2D>().radius );
				yield return new WaitForSeconds(0.094f);
			}
			Destroy (VFX);
            Destroy (gameObject);
			Debug.Log("BAM!");
			stopShock();
	}*/
	
	
	IEnumerator playerShockWave() {
			GetComponent<CircleCollider2D>().radius = 0.6f;
			GameObject blastArt = GameObject.FindGameObjectWithTag("blastart");
			newScale = 1f;
			for (int i = 0; i < 8; i++){
				GetComponent<CircleCollider2D>().radius += 0.2375f;
				blastArt.transform.localScale = new Vector3(newScale, newScale, newScale);
				blastArt.transform.position = this.transform.position;
				//Debug.Log("Radius is:" + GetComponent<CircleCollider2D>().radius );
				newScale += 0.3f;
				yield return new WaitForSeconds(0.094f);
			}
			//Debug.Log("BAM!");
			stopShock();
	}
		
	   
	IEnumerator selfDestructHit(GameObject VFX){
            yield return new WaitForSeconds(1f);
            Destroy (VFX);

			//Debug.Log("Pulse Removed.");
			//StopCoroutine (selfDestructHit);
    }
	
	IEnumerator EndKnockBack(Rigidbody2D otherRB){
              yield return new WaitForSeconds(0.2f);
              if (otherRB != null){
				otherRB.velocity= new Vector3(0,0,0);
			  }
    }
	  
	void stopShock () {
		isPulsing = false;
		GetComponent<CircleCollider2D>().radius = 0.15f;
		//Debug.Log("Radius is:" + GetComponent<CircleCollider2D>().radius );
		//Debug.Log("Pulse Stopped.");
	}
	
	
}
