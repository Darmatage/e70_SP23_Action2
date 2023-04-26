using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit_Items : MonoBehaviour{
      public string NextLevel = "Gratis_Work";
      public GameObject DoorClosed;
      public GameObject DoorOpen;

      private bool doorIsClosed = true; 

      void Start(){
            // gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            DoorClosed.SetActive(true);
            DoorOpen.SetActive(false);
            gameObject.GetComponent<Collider2D>().enabled = false;
      }

      void Update(){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] enemyShooters = GameObject.FindGameObjectsWithTag("enemyShooter");
            int totalEnemies = enemies.Length + enemyShooters.Length;
            // piecesCollected = gameHandler.thePieces;
            // Debug.Log("Total Enemies: "+ totalEnemies);

            if (totalEnemies == 0 && doorIsClosed){
                  // Debug.Log("All enemies dead!");
                  doorIsClosed = false;
                  DoorClosed.SetActive(false);
                  DoorOpen.SetActive(true);
                  gameObject.GetComponent<Collider2D>().enabled = true;
            }
            else if (totalEnemies > 0 && doorIsClosed){
                  gameObject.GetComponent<Collider2D>().enabled = false;
            }
      }

      public void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Player"){
                  SceneManager.LoadScene (NextLevel);
            }
      }
}