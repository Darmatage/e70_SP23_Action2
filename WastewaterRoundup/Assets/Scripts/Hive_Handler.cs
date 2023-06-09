using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive_Handler : MonoBehaviour{
	
	private Animator anim;
	private float theTimer = 0f;
	public float spawnRate;
	public float spawnRateStart = 5f;
	public float spawnRateEncounter = 2f;
	public float longtermSpawnRate = 8f;
	//public float spawnRadiusInner = 1.5f;
	//public float spawnRadiusOuter = 4f;
	
	public int maxInitialEnemies = 10;
	private int currentEnemies = 0;
	
	public GameObject[] hiveStrands;
	public int numStrands;
	
	public GameObject theLoot;
	
	public Hive_Spawner m_Hive_Spawner;
	
	private Transform player;
	private float distToPlayer;
	public float speedUpDistance = 2f;
	
    void Start(){
		anim = GetComponentInChildren<Animator>();
		spawnRate = spawnRateStart;
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		m_Hive_Spawner.AddNewBacteria();
		numStrands = hiveStrands.Length;
		
    }

	void Update(){
		distToPlayer = Vector3.Distance(transform.position, player.position);
		if (distToPlayer <= speedUpDistance){
			spawnRate = spawnRateEncounter;
		} else {spawnRate = spawnRateStart;}
	}

    void FixedUpdate(){
        
		if (currentEnemies < maxInitialEnemies){
			if (theTimer <= spawnRate){
				theTimer += 0.01f;
			} 
			else {
				m_Hive_Spawner.AddNewBacteria();
				currentEnemies += 1;
				theTimer = 0;
			}
		}
		else {
			if (theTimer <= longtermSpawnRate){
				theTimer += 0.01f;
			} 
			else {
				m_Hive_Spawner.AddNewBacteria();
				theTimer = 0;
			}	
		}
    }
	
	
	/*public void AddNewBacteria(){
		//prepare a random spawn position for the new follower
		float randX = Random.Range (-spawnRadiusOuter, spawnRadiusOuter); 
		float randY = Random.Range (-spawnRadiusOuter, spawnRadiusOuter);
		Vector2 newPos = new Vector2 (transform.position.x + randX, transform.position.y + randY);
		
		//instantiate the new follower
		GameObject thisNewEnemy = Instantiate (enemyBacteria, newPos, Quaternion.identity);
		if (GameObject.FindWithTag("EnemyFolder") != null){
			thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
		}
	}*/
	
	
	public void StrandDeath(){
		//if hive contents == null, then kill the hive, instantiate theLoot
		numStrands -= 1;
		if (numStrands <= 0){
			StartCoroutine("HiveDeath");
			
			anim.SetTrigger("DEATH");
		}
	}
	
	IEnumerator HiveDeath(){
		yield return new WaitForSeconds(2.6f);
		Instantiate (theLoot, transform.position, Quaternion.identity);
		GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds(1.3f);
		Destroy(gameObject);
    }
	
	
}
