/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAlphaTime : MonoBehaviour {

        public GameObject imageToFade;
        public float alphaLevel = 0f;

        void Start(){
                //imageToFade.GetComponent<Image>.color = new Color(1, 1, 1, alphaLevel);
                StartCoroutine(FadeIn(imageToFade));
        }

        IEnumerator FadeIn(GameObject fadeImage){
            // imageToFade.GetComponent<Image>.color = new Color(1, 1, 1, alphaLevel); 
			   for (int i = 0; i < 25; i++){
                        alphaLevel += 0.08f;
                        yield return null;
                        fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
                        Debug.Log("Alpha is: " + alphaLevel);
                }
        }
} */