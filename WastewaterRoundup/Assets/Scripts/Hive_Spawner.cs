using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive_Spawner : MonoBehaviour
{
    public GameObject enemyBacteria;
	
	public float spawnRadiusInner = 0.5f;
	public float spawnRadiusOuter = 2f;
	
	
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
		
		//instantiate the new follower
		GameObject thisNewEnemy = Instantiate (enemyBacteria, newPos, Quaternion.identity);
		if (GameObject.FindWithTag("EnemyFolder") != null){
			thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
		}
		
	}
	
}
