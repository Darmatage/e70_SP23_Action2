using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit_Items : MonoBehaviour{
      public string NextLevel = "Gratis_Work";
      public GameObject DoorClosed;
      public GameObject DoorOpen;

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


            if (totalEnemies == 0){
                  DoorClosed.SetActive(false);
                  DoorOpen.SetActive(true);
                  gameObject.GetComponent<Collider2D>().enabled = true;
            }
            else {
                  gameObject.GetComponent<Collider2D>().enabled = false;
            }
      }

      public void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Player"){
                  SceneManager.LoadScene (NextLevel);
            }
      }
}