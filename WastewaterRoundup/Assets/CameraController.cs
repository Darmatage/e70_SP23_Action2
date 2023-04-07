using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; 
    
    // Update is called once per frame
    void Update()
    {
        // For each frame, set the position of the camera
        // to the position of the player. 
        // The x and y position will be of the player, but the z position
        // will remain to that of the camera. 
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
