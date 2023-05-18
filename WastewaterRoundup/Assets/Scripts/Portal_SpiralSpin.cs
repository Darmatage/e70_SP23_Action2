using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_SpiralSpin : MonoBehaviour{

	public float rotationSpeed = 30f;
	public float scaleAmt = 0.1f;
	public float scaleMax = 12f;
	public float scaleMin = 5f;
	private float theSize = 0;
	private bool scaleUp = true;

	void Start(){
		transform.localScale = new Vector3(scaleMin,scaleMin,1);
	}

	void Update(){
		//rotation
		transform.Rotate (new Vector3 (0, 0, rotationSpeed) * Time.deltaTime); 
	}
	
	void FixedUpdate(){
		//scale up and down
		if (scaleUp == true){
			theSize += scaleAmt;
		}
		else {
			theSize -= scaleAmt;
		}
		
		transform.localScale = new Vector3(theSize,theSize,5);
		
		if ((scaleUp == true)&&(theSize >= scaleMax)){
			scaleUp=false;
		}
		else if ((scaleUp == false)&&(theSize <= scaleMin)){
			scaleUp=true;
		}
    }
}
