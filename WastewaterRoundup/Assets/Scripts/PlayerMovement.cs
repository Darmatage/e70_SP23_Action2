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
        Debug.Log("Movement Script");
        // Get the input from the player and save it in variables
        // horizontal and vertical 
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        // Make a new vector called direction that tells the player 
        // where to move 
        Vector2 direction = new Vector2(dirX, dirY);

        // Change the velocity of the player to move in the direction
        // specified by `direction` with the `moveSpeed`
        rb.velocity = direction * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("Doing the Big Suck");
            CollectPoop();
        }
    }

    void CollectPoop(){
        Debug.Log("Collecting the Poop!");
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);

        foreach (Collider collider in colliders) {
            if (collider.gameObject.CompareTag("PickUp")) {
                Destroy(collider.gameObject);
            }
        }
    }

    
}
