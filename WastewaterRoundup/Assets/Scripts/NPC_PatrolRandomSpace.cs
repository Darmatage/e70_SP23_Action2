
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// TODO: Fix the patrol space. 
// TODO: Is 5 oxygen points/second too much? 

public class NPC_PatrolRandomSpace : MonoBehaviour {

       public float speed = 10f;
       private float waitTime;
       public float startWaitTime = 0.5f;

       public Vector2 moveSpot;
       private Vector2 initialPosition; 
       public float minX;
       public float maxX;
       public float minY;
       public float maxY;

       private GameObject player;
       private GameHandler gameHandler;

       void Start(){
              waitTime = startWaitTime;
              initialPosition = transform.position; 
              Debug.Log("Initial Position: " + initialPosition.ToString());
              float randomX = Random.Range(initialPosition.x + minX, initialPosition.x + maxX);
              float randomY = Random.Range(initialPosition.y + minY, initialPosition.y + maxY);
              moveSpot = new Vector2(randomX, randomY);
              Debug.Log("Moving To: " + moveSpot);
              
              player = GameObject.FindGameObjectWithTag("Player");
            if (GameObject.FindWithTag("GameHandler") != null) {
                gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler> ();
            }
            StartCoroutine(StealOxygen());
       }

       void Update(){
              transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);

              if (Vector2.Distance(transform.position, moveSpot) < 0.2f){
                     if (waitTime <= 0){
                            float randomX = Random.Range(initialPosition.x + minX, initialPosition.x + maxX);
                            float randomY = Random.Range(initialPosition.y + minY, initialPosition.y + maxY);
                            moveSpot = new Vector2(randomX, randomY);
                            waitTime = startWaitTime;
                     } else {
                            waitTime -= Time.deltaTime;
                     }
              }
              }

              IEnumerator StealOxygen(){
              while (true){
                     float distance = Vector3.Distance(player.transform.position, transform.position);
                     if (distance <= 5f){
                            if (gameHandler.playerOxygen > 5f){
                                   Debug.Log("Got Too Close: Reducing Oxygen By 5");
                                   gameHandler.playerOxygen = gameHandler.playerOxygen - 5f;
                            } else {
                                   Debug.Log("Very Weak: Oxygen 0");
                                   gameHandler.playerOxygen = 0f;
                            }
                     }
                     yield return new WaitForSeconds(1f); // Wait for 1 second
              }
       }
}
