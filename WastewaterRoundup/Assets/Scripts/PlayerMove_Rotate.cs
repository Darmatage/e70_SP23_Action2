using UnityEngine;
using System;
using System.Collections;

public class PlayerMove_Rotate :  MonoBehaviour {

      public float moveSpeed = 5f;
      public float rotationSpeed = 720f;

      void Update(){
            float horizontalInput = Input.GetAxis ("Horizontal");
            float verticalInput = Input.GetAxis ("Vertical");
            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
            float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
            moveDirection.Normalize();

            transform.Translate(moveDirection * moveSpeed * inputMagnitude * Time.deltaTime, Space.World);

            if (moveDirection != Vector2.zero) {
                  Quaternion toRotation = Quaternion.LookRotation (Vector3.forward, moveDirection);
                  transform.rotation = Quaternion.RotateTowards (transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
      }

}
