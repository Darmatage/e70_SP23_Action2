using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    
	  private GameObject target;
      public float camSpeed = 4.0f;

      void Start(){
            target = GameObject.FindWithTag("Player");
      }

      void FixedUpdate () {
            Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)target.transform.position, camSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
      }
	
	
	
	
	/*
	private Transform player; 
    
	void Start(){
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	
    // Update is called once per frame
    void Update()
    {
        // For each frame, set the position of the camera
        // to the position of the player. 
        // The x and y position will be of the player, but the z position
        // will remain to that of the camera. 
       
	   transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
	*/
}
