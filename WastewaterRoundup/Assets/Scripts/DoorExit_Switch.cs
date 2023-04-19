
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit_Switch : MonoBehaviour{

      public GameObject DoorClosedArt;
      public GameObject DoorOpenArt;
      public string NextScene = "Gratis_Work";

      void Start(){
            DoorClosedArt.SetActive(true);
            DoorOpenArt.SetActive(false);
            gameObject.GetComponent<Collider2D>().enabled = false;
      }

      public void DoorOpen(){
            DoorClosedArt.SetActive(false);
            DoorOpenArt.SetActive(true);
            gameObject.GetComponent<Collider2D>().enabled = true;
      }

     // When the player collides with the door, load the next scene.
      void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Player"){
                  DoorOpen();
                  SceneManager.LoadScene(NextScene);
            }
      }
}