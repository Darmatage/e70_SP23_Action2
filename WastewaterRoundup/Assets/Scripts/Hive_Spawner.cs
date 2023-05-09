using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive_Spawner : MonoBehaviour
{
	//enemy variables
	public GameObject[] enemies;
	public GameObject spawnVisual;
	private int rangeEndEnemies; 
	public int spawnSelect = 0;
	
	private GameObject spawnParticles;

	//location variables
	public Transform[] spawnPoints;
	private int rangeEndPositions; 
	private Transform spawnPoint; 
	
	//public Animator anim;
	
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
		
		StartCoroutine(newBac());
		
		/*
		//get random location
		int SPnum = Random.Range(0, rangeEndPositions);
        spawnPoint = spawnPoints[SPnum];
		Vector2 newPos = new Vector2 (spawnPoint.position.x, spawnPoint.position.y);
		
		//anim = spawnPoint.GetComponentInChildren<Animator>();
		//Debug.Log(spawnPoint.name + "just spawned an enemy! The animator is:" + anim.name);
		
		//choose random enemy and spawn at location
		spawnSelect = Random.Range(0, rangeEndEnemies);
		//anim.SetTrigger("Spawn");
		GameObject spawnParticles = Instantiate (spawnVisual, newPos, Quaternion.identity);
		GameObject thisNewEnemy = Instantiate (enemies[spawnSelect], newPos, Quaternion.identity);
			if (GameObject.FindWithTag("EnemyFolder") != null){
				thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
			}
		StartCoroutine(removeParticles(spawnParticles));
		*/
		
		
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
	
	IEnumerator removeParticles(GameObject VFX){
            yield return new WaitForSeconds(3f);
            Destroy (VFX);
    }
	
	IEnumerator newBac() {
		//get random location
		int SPnum = Random.Range(0, rangeEndPositions);
        spawnPoint = spawnPoints[SPnum];
		Vector2 newPos = new Vector2 (spawnPoint.position.x, spawnPoint.position.y);
		
		//anim = spawnPoint.GetComponentInChildren<Animator>();
		//Debug.Log(spawnPoint.name + "just spawned an enemy! The animator is:" + anim.name);
		
		//choose random enemy and spawn at location
		spawnSelect = Random.Range(0, rangeEndEnemies);
		//anim.SetTrigger("Spawn");
		GameObject spawnParticles = Instantiate (spawnVisual, newPos, Quaternion.identity);
		StartCoroutine(removeParticles(spawnParticles));
		yield return new WaitForSeconds(2.5f);
		GameObject thisNewEnemy = Instantiate (enemies[spawnSelect], newPos, Quaternion.identity);
			if (GameObject.FindWithTag("EnemyFolder") != null){
				thisNewEnemy.transform.parent = GameObject.FindWithTag("EnemyFolder").GetComponent<Transform>();
			}
		
	}
	
}
