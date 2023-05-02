using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShmutz : MonoBehaviour{

	public GameObject[] shmutzes;
	
	public bool isSystem = true; // use this script for both making and moving indivisual shmutz
	public int shmutzAmount = 200;
	
	private Transform upperLeft;
	private Transform lowerRight;
	private Transform waterShmutzFolder;

	//shmutz-only parameters
	private Vector2 shmutzStartPos;
	private float moveSpeed;
	private float rotationSpeed;
	private Color shmutzColor;
	private Rigidbody2D rb2D;

    void Start(){
		upperLeft = GameObject.FindWithTag("waterShmutzUpLeft").GetComponent<Transform>();
		lowerRight = GameObject.FindWithTag("waterShmutzDownRight").GetComponent<Transform>();
		
        if (isSystem){
			waterShmutzFolder = GameObject.FindWithTag("waterShmutzFolder").GetComponent<Transform>();
			MakeTheShmutz();
		}
		else {
			rb2D = GetComponent<Rigidbody2D>();
		}
    }

    void FixedUpdate(){
		
        if (!isSystem){
			//#1 Move Right-ish at movespeed
             //rb2D.AddForce(transform.forward * moveSpeed);
			 //rb2D.AddForce(new Vector2(-600, 600) * moveSpeed);
			Vector2 direction = new Vector2((float)Random.Range(-10,10), (float)Random.Range(-10,10));
			float force = (float)Random.Range(-0.25f,0.3f);
			rb2D.AddForce(direction * force);
			 
			//#2 Re-cycle shmutz: teleport when reaching boundary
			//float distanceX = transform.position.x - lowerRight.position.x;
			//float distanceY = transform.position.y - lowerRight.position.y;
			//if I am too far to the right, teleport left to the left boundary
			
			//if too far left:
			if (transform.position.x > lowerRight.position.x){
				transform.position = new Vector2(upperLeft.position.x, transform.position.y);
			}
			
			//if too far right:
			if (transform.position.x < upperLeft.position.x){
				transform.position = new Vector2(lowerRight.position.x, transform.position.y);
			}
			
			//if too far down:
			if (transform.position.y < lowerRight.position.y){
				transform.position = new Vector2(transform.position.x, upperLeft.position.y);
			}
			
			//if too far up:
			if (transform.position.y > upperLeft.position.y){
				transform.position = new Vector2(transform.position.x, lowerRight.position.y);
			}
			
			if (direction != Vector2.zero) {
                  Quaternion toRotation = Quaternion.LookRotation (Vector3.forward, direction);
                  transform.rotation = Quaternion.RotateTowards (transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
			}
		}
			
    }
	
	public void MakeTheShmutz(){
		//only called for the system, not individual pieces
		for (int i = 0; i <= shmutzAmount; i++){
			//spawn parameters
			int chooseShmutz = Random.Range(0,shmutzes.Length);
			
			float posX = Random.Range(upperLeft.position.x, lowerRight.position.x);
			float posY = Random.Range(upperLeft.position.y, lowerRight.position.y);
			shmutzStartPos = new Vector2(posX, posY);
			
			GameObject newShmutz = Instantiate(shmutzes[chooseShmutz], shmutzStartPos, Quaternion.identity);
			newShmutz.transform.parent = waterShmutzFolder;
			
			//new object paramters
			float thisMoveSpeed = Random.Range(1f,3f);
			int layerOrderRand = Random.Range(80,120);
			float distColor = layerOrderRand * 0.006f;
			shmutzColor = new Color(distColor,distColor,distColor,(layerOrderRand-20)*0.01f);
			float thisRotationSpeed = Random.Range(50,100);
			
			newShmutz.GetComponentInChildren<WaterShmutz>().isSystem = false;
			newShmutz.GetComponentInChildren<WaterShmutz>().moveSpeed = thisMoveSpeed;//not yet used
			newShmutz.GetComponentInChildren<WaterShmutz>().rotationSpeed = thisRotationSpeed;
			newShmutz.GetComponentInChildren<SpriteRenderer>().color = shmutzColor;
			newShmutz.GetComponentInChildren<SpriteRenderer>().sortingOrder = layerOrderRand;
			
		}
		
	}
	
	
	
}
