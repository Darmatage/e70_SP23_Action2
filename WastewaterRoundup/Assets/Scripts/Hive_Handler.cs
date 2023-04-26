using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive_Handler : MonoBehaviour{
	
	public GameObject enemyBacteria;
	private float theTimer = 0f;
	public float spawnRate = 1f;
	public float spawnRadiusInner = 1.5f;
	public float spawnRadiusOuter = 4f;
	
	public int maxEnemies = 10;
	private int currentEnemies = 0;
	
	public GameObject[] hiveStrands;
	public int numStrands;
	
	public GameObject theLoot;
	
    void Start(){
        AddNewBacteria();
		numStrands = hiveStrands.Length;
    }

    void FixedUpdate(){
        
		if (currentEnemies < maxEnemies){
			if (theTimer <= spawnRate){
				theTimer += 0.01f;
			} else {
				AddNewBacteria();
				currentEnemies += 1;
				theTimer = 0;
			}
		}
    }
	
	
	public void AddNewBacteria(){
		//prepare a random spawn position for the new follower
		float randX = Random.Range (-spawnRadiusOuter, spawnRadiusOuter); 
		float randY = Random.Range (-spawnRadiusOuter, spawnRadiusOuter);
		Vector2 newPos = new Vector2 (transform.position.x + randX, transform.position.y + randY);
		
		//instantiate the new follower
		GameObject thisNewEnemy = Instantiate (enemyBacteria, newPos, Quaternion.identity);
		if (GameObject.FindWithTag("EnemyFolder") != null){
			thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
		}
		
	}
	
	
	public void StrandDeath(){
		//if hive contents == null, then kill the hive, instantiate theLoot
		numStrands -= 1;
		if (numStrands <= 0){
			Instantiate (theLoot, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
	
	
}
