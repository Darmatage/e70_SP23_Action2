using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive_Spawner : MonoBehaviour
{
    public GameObject bigRangedEnemy;
	public GameObject lilRangedEnemy;
	public GameObject bigMeleeEnemy;
	public GameObject lilMeleeEnemy;
	public GameObject mrSucc;
	
	public int spawnSelect = 0;
	
	public float spawnRadiusInner = 0.5f;
	public float spawnRadiusOuter = 2.5f;
	
	
	// Start is called before the first frame update
    void Start() {
    
        
    }

    // Update is called once per frame
    void Update() {
    
        
    }
	
	public void AddNewBacteria(){
		//prepare a random spawn position for the new follower
		float randX = Random.Range (-spawnRadiusOuter, spawnRadiusOuter); 
		float randY = Random.Range (-spawnRadiusOuter, spawnRadiusOuter);
		Vector2 newPos = new Vector2 (transform.position.x + randX, transform.position.y + randY);
		
		spawnSelect = Random.Range (1, 6);
		
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
		
	}
	
}
