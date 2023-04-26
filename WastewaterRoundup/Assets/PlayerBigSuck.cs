// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerBigSuck : MonoBehaviour
// {
//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.S)) {
//             CollectPoop();
//         }
//     }

//     void CollectPoop(){
//         Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);

//         foreach (Collider collider in colliders) {
//             if (collider.gameObject.CompareTag("PickUp")) {
//                 Destroy(collider.gameObject);
//             }
//         }
//     }
// }
