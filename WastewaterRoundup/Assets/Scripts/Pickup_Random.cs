using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Pickup_Random : MonoBehaviour  {

      //define rectangle for random positon
      public float width = 1;
      public float height = 2;

      private Vector2 rect1;
      private Vector2 rect2;

      void Start(){
            Vector3 pos = transform.position;
            rect1 = new Vector2(pos.x - width/2, pos.y + height/2);
            rect2 = new Vector2(pos.x + width/2, pos.y - height/2);
            RandomPos();
      }

      void Update(){
            //test position change
            if (Input.GetKeyDown("p")){
                  RandomPos();
            }
      }

      public void RandomPos(){
            float xRand = Random.Range(rect1.x, rect2.x);
            float yRand = Random.Range(rect1.y, rect2.y);

            transform.position = new Vector2(xRand, yRand);
      }

      void OnDrawGizmos(){
            Gizmos.DrawWireCube(transform.position, new Vector3(width,height,0));
      }
}
