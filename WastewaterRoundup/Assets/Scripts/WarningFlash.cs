using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningFlash : MonoBehaviour{

	public GameObject fadeHighlight;
	private float pulseHold = 1f;
	private float pulseDelay = .6f;
	private float pulseSpeed = 0.025f;
	private CanvasRenderer fadeHighlightRend;
	private bool timeToFadeOut = false;
	private bool timeToFadeIn = false;
	private float fadeAlpha = 0f;

	void Awake(){
		fadeHighlightRend = fadeHighlight.GetComponent<CanvasRenderer>();
		//fadeHighlightRend.material.color = new Color(2.5f, 2.2f, 0.3f, 0f);
		//fadeHighlightRend.SetAlpha(0.5f);
	}

	void Start(){
		//StartCoroutine(RandomDelay());
		timeToFadeIn = true;
	}

	void FixedUpdate(){
		if (timeToFadeIn){
			fadeAlpha += pulseSpeed;
			//fadeHighlightRend.material.color = new Color(2.5f, 2.2f, 0.3f, fadeAlpha);
			fadeHighlightRend.SetAlpha(fadeAlpha);
			if (fadeAlpha >= 0.7f){
				fadeAlpha = 0.7f;
				StartCoroutine(PulseFull());
			}
		}
		else if (timeToFadeOut){
			fadeAlpha -= (pulseSpeed / 2);
			//fadeHighlightRend.material.color = new Color(2.5f, 2.2f, 0.3f, fadeAlpha);
			fadeHighlightRend.SetAlpha(fadeAlpha);
			if (fadeAlpha <= 0f){
				fadeAlpha = 0f;
				StartCoroutine(PulsePause());
			}	
		}
	}

	//delay start of pulsing, so neighboring pickups do not pulse the same
	IEnumerator RandomDelay(){
		float randDelay = Random.Range(0.1f, 2.0f);
		yield return new WaitForSeconds(randDelay);
		timeToFadeIn = true;
	}

	//stay at full strength before fading away
	IEnumerator PulseFull(){
		yield return new WaitForSeconds(pulseHold);
		timeToFadeIn = false;
		timeToFadeOut = true;
	}

	//pause before next pulse
	IEnumerator PulsePause(){
		yield return new WaitForSeconds(pulseDelay);
		timeToFadeOut = false;
		timeToFadeIn = true;
	}

}  