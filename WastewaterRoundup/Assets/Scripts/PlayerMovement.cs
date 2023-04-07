using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We want to create a new script that controls player movement. 
public class PlayerMovement : MonoBehaviour
{
    // move speed is a variable that helps us make the player 
    // move faster or slower
    public float moveSpeed = 5f; 

    // get access to the body of the player that we control with code
    private Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbdy component of the player, and 
        // save it to the variable rb so that we can control
        // it later. 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input from the player and save it in variables
        // horizontal and vertical 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Make a new vector called movement that tells the player 
        // where to move 
        Vector2 movement = new Vector2(horizontal, vertical);

        // Change the velocity of the player to move in the direction
        // specified by `movement` with the `moveSpeed`
        rb.velocity = movement * moveSpeed;
    }

    
}
