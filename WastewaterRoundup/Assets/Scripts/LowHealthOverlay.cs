






/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowHealthOverlay : MonoBehaviour
{
    public float fadeSpeed = 4f;
	
	private bool goingdown = true;
	private bool goingup = false;
	private bool alreadyDown = false;
	private bool alreadyUp = false;
	

	
	// Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeOutObject");
    }

    // Update is called once per frame
    void Update()
    {
        /*while (goingdown == true) {
				if (alreadyDown == false){
					StartCoroutine("FadeOutObject");
					alreadyDown = true;
				}
				if (this.GetComponent<Image>().material.color.a == 0) {
					StopCoroutine("FadeOutObject");
					goingdown = false;
					alreadyDown = false;
				}
		}
		
		while (goingup == true) {
				if (alreadyUp == false){
					StartCoroutine("FadeInObject");
					alreadyUp = true;
				}
				if (this.GetComponent<Image>().material.color.a == 1) {
					StopCoroutine("FadeInObject");
					goingup = false;
					alreadyUp = false;
				}
		} */
   // }// END OF UPDATE 
	
	
	/*public IEnumerator FadeOutObject() {
		while (this.GetComponent<Image>().material.color.a > 0) {
			Color objectColor = this.GetComponent<Image>().material.color;
			float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
			
			objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
			this.GetComponent<Image>().material.color = objectColor;
			yield return null;
		}
		
	}
	
	public IEnumerator FadeInObject() {
		while (this.GetComponent<Image>().material.color.a < 1) {
			Color objectColor = this.GetComponent<Image>().material.color;
			float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
			
			objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
			this.GetComponent<Image>().material.color = objectColor;
			yield return null;
		}
		
	}
	
	
	
}*/