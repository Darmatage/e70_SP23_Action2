using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler_PlayerFollowers : MonoBehaviour{
	
	//public int growthTheshold = 100;
	private Transform playerPos;
	public GameObject playerFollow;
	public static int playerFollowers = 0;
	public List<GameObject> playerFollowerList = new List<GameObject>();
	private GameHandler GameHandler;
	
	void Start(){
		
		if (GameObject.FindWithTag ("GameHandler") != null) {
                GameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
        }
		playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
		AddToFollowerList(playerFollowers);
	}
	
	
	void Update(){
		
		
			// test add a follower:
			if (Input.GetKeyDown("i")){
				playerFollowers += 1;
				AddToFollowerList(1);
				GameHandler.updateStatsDisplay();
			}
		
		
		
		// test remove a follower:
		if (Input.GetKeyDown("o")){
			RemoveFromFollowerList();
		}
	}
	
	
	public void AddToFollowerList(int newFollowers){
		//instantiate a new follower and add to the list of followers
		if (newFollowers > 0){
			for (int i=0; i <= (newFollowers-1); i++){
				//prepare a random spawn position for the new follower
				float randX = Random.Range (-2, 2); float randY = Random.Range (-2, 2);
				Vector2 newPos = new Vector2 (playerPos.position.x + randX, playerPos.position.y + randY);
				//instantiate the new follower
				GameObject thisNewFollower = Instantiate (playerFollow, newPos, Quaternion.identity);
				if (GameObject.FindWithTag("PlayerFollowers") != null){
					thisNewFollower.transform.parent = GameObject.FindWithTag("PlayerFollowers").GetComponent<Transform>();
				}
				//add the new follower to the List<>
				playerFollowerList.Add(thisNewFollower);
			}
		}
	}
	
	public void RemoveFromFollowerList(){
		//remove a follower from the list and destroy the GameObject
		GameObject followerToRemove = playerFollowerList[playerFollowerList.Count - 1];
		playerFollowerList.RemoveAt(playerFollowerList.Count - 1);
		Destroy(followerToRemove);
	}
	
	public void RemoveTHISFromFollowerList(GameObject thisFollower){
		//remove a follower from the list and destroy the GameObject
		//GameObject followerToRemove = playerFollowerList[playerFollowerList.Count - 1];
		//playerFollowerList.RemoveAt(playerFollowerList.Count - 1);
		//Destroy(followerToRemove);
	}
	
	
	public void ChangeFollowerColor(){
		//at certain thresholds, change to a new color (random or set color?)
		
		
	}
	
	
}





//NOTE: to make sure the object being added to a List is unique:
//if(!enemies.Contains(currentEnemy))
//       enemies.Add(currentEnemy);
//}
