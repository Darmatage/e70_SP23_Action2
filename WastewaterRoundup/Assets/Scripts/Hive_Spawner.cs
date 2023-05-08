using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive_Spawner : MonoBehaviour
{
	//enemy variables
	public GameObject[] enemies;
	private int rangeEndEnemies; 
	public int spawnSelect = 0;

	//location variables
	public Transform[] spawnPoints;
	private int rangeEndPositions; 
	private Transform spawnPoint; 
	
	private Animator anim;
	
	//public float spawnRadiusInner = 0.5f;
	//public float spawnRadiusOuter = 2.5f;
	
	
	// Start is called before the first frame update
    void Start() {
		rangeEndPositions = spawnPoints.Length;
		rangeEndEnemies = enemies.Length;
    }

    // Update is called once per frame
    void FixedUpdate() {
    
        
    }
	
	public void AddNewBacteria(){
		//prepare a random spawn position for the new follower
		//float randX = Random.Range (-spawnRadiusOuter, spawnRadiusOuter); 
		//float randY = Random.Range (-spawnRadiusOuter, spawnRadiusOuter);
		//Vector2 newPos = new Vector2 (transform.position.x + randX, transform.position.y + randY);
		
		//get random location
		int SPnum = Random.Range(0, rangeEndPositions);
        spawnPoint = spawnPoints[SPnum];
		Vector2 newPos = new Vector2 (spawnPoint.position.x, spawnPoint.position.y);
		
		anim = spawnPoint.GetComponentInChildren<Animator>();
		
		//choose random enemy and spawn at location
		spawnSelect = Random.Range(0, rangeEndEnemies);
		anim.SetTrigger("Spawn");
		GameObject thisNewEnemy = Instantiate (enemies[spawnSelect], newPos, Quaternion.identity);
		if (GameObject.FindWithTag("EnemyFolder") != null){
			thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
		}
		
		/*
		if (spawnSelect == 1) {
			
			//instantiate the new follower
			GameObject thisNewEnemy = Instantiate (lilMeleeEnemy, newPos, Quaternion.identity);
				if (GameObject.FindWithTag("EnemyFolder") != null){
					thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
				}
			
		}
		else if (spawnSelect == 2) {
			
			//instantiate the new follower
			GameObject thisNewEnemy = Instantiate (bigMeleeEnemy, newPos, Quaternion.identity);
				if (GameObject.FindWithTag("EnemyFolder") != null){
					thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
				}
			
		}
		else if (spawnSelect == 3) {
			
			//instantiate the new follower
			GameObject thisNewEnemy = Instantiate (bigRangedEnemy, newPos, Quaternion.identity);
				if (GameObject.FindWithTag("EnemyFolder") != null){
					thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
				}
			
		}
		else if (spawnSelect == 4) {
			
			//instantiate the new follower
			GameObject thisNewEnemy = Instantiate (lilRangedEnemy, newPos, Quaternion.identity);
				if (GameObject.FindWithTag("EnemyFolder") != null){
					thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
				}
			
		}
		else if (spawnSelect == 5) {
			
			//instantiate the new follower
			GameObject thisNewEnemy = Instantiate (mrSucc, newPos, Quaternion.identity);
				if (GameObject.FindWithTag("EnemyFolder") != null){
					thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
				}
			
		}
		*/
		
	}
	
}
