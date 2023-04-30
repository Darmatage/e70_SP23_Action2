using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerGetHurt: MonoBehaviour{
//this script manages gethurt and death animation

      //public Animator anim;
      private Rigidbody2D rb2D;

      void Start(){
           //anim = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();           
      }

      public void playerHit(){
            //anim.SetTrigger ("getHurt");
      }

      public void playerDead(){
            rb2D.isKinematic = true;
			GetComponent<Collider2D>().enabled = false;
            //anim.SetTrigger ("KO");
      }
}