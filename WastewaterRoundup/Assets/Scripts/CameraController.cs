using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour{
    
	  private GameObject target;
	  public Vector3 offset;
	  public float damping = 0.69f;
	  
	  private Vector3 velocity = Vector3.zero;
      public float camSpeed = 4.0f;

      void Start(){
            target = GameObject.FindWithTag("Player");
      }

      void Update () {
			//Vector3 movePosition = target.transform.position + offset;
			//transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
			
			Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)target.transform.position, camSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
      }
}


