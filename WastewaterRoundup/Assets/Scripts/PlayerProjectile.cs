using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour{

      public int damage = 20;
      public GameObject hitEffectAnim;
      public float SelfDestructTime = 4.0f;
      public float SelfDestructVFX = 0.5f;
      private SpriteRenderer projectileArt;

      void Start(){
           projectileArt = GetComponentInChildren<SpriteRenderer>();
           selfDestruct();
      }

      //if the bullet hits a collider, play the explosion animation, then destroy the effect and the bullet
      void OnTriggerEnter2D(Collider2D other){
            //if (hitAlready == false) {
				if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
					  //gameHandlerObj.playerGetHit(damage);
					  Debug.Log("We hit " + other.name);
					  other.gameObject.GetComponent<EnemyMeleeDamage>().TakeDamage(damage);
				}
				if (other.gameObject.layer == LayerMask.NameToLayer("Clumps")) {
					  Debug.Log("We hit " + other.name);
					  other.gameObject.GetComponent<BreakableClump>().TakeDamage(damage);
				}
				if (other.gameObject.layer == LayerMask.NameToLayer("strand")) {
					  Debug.Log("We hit " + other.name);
					  other.gameObject.GetComponent<Hive_Strand>().HitStrand();
				}
				if (other.gameObject.layer == LayerMask.NameToLayer("singularstrand")) {
					  Debug.Log("We hit " + other.name);
					  other.gameObject.GetComponent<Singular_Hive_Strand>().HitStrand();
				}
			   if (other.gameObject.tag != "Player" && other.gameObject.tag != "blast" && other.gameObject.tag != "Follower" && other.gameObject.tag != "bullet") {
					  GameObject animEffect = Instantiate (hitEffectAnim, transform.position, Quaternion.identity);
					  GetComponent<Collider2D>().enabled = false;
					  projectileArt.enabled = false;
					  //hitAlready = true;
					  //AudioSource.Play();
					  StartCoroutine(selfDestructHit(animEffect));
				}
			//}
      } 

      IEnumerator selfDestructHit(GameObject VFX){
            yield return new WaitForSeconds(SelfDestructVFX);
            Destroy (VFX);
            Destroy (gameObject);
      }

      IEnumerator selfDestruct(){
            yield return new WaitForSeconds(SelfDestructTime);
            Destroy (gameObject);
      }
}
