using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocomotionHandler : MonoBehaviour
{
    public PlayerManager playerManager;
    public Rigidbody2D rb;
    public BoxCollider2D boxCol;

    public float speed;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
    }

    /// <summary>
    /// Once every .02 seconds, this function is called
    /// </summary>
    public void FixedUpdate()
    {
        SetMovementMode(playerManager.playerInput.moveDirection, rb.velocity);
        SetPlayerFacing(rb.velocity);
    }

    /// <summary>
    /// When called, this function sets the movement mode based on the jet active boolean 
    /// </summary>
    /// <param name="moveDirection">direction to move player</param>
    /// <param name="velocity">the velocity of player rigidbody</param>
    public void SetMovementMode(Vector2 moveDirection, Vector2 velocity)
    {
        // Check if jet is active
        if (playerManager.jetPackHandler.enabled == true)
        {
            // Enable jet mode
            SetJetMovement(moveDirection, velocity);
        }
        else if(playerManager.jetPackHandler.enabled == false)
        {
            // Enable walk mode
            SetWalkMovement(moveDirection, velocity);
        }


    }

    /// <summary>
    /// When called, this function sets the facing direction of the player based on the x value of the rigidbody velocity
    /// </summary>
    /// <param name="velocity">the velocity of the rigidbody</param>
    public void SetPlayerFacing(Vector2 velocity)
    {
        // Check if the current x value of the rigidbody velocity is less than zero
        if (velocity.x < 0)
        {
            // Set the x value of the scale to -1 to face left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // Set the x value of the scale to 1 to face right
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    /// <summary>
    /// When called, this function sets the jet mode movement
    /// </summary>
    /// <param name="moveDirection">the direction of input</param>
    /// <param name="velocity">the velocity of the rigidbody</param>
    public void SetJetMovement(Vector2 moveDirection, Vector2 velocity)
    {
        // Get the rigidbody velocity and store it
        velocity = rb.velocity;

        // Add the movement direction and speed to the stored velocity variable
        velocity += moveDirection * speed * Time.fixedDeltaTime;

        // Set the stored velocity variable to stop when top speed is reached
        velocity = Vector2.ClampMagnitude(velocity, speed);

        // Set the rigidbody velocity to the stored velocity variable
        rb.velocity = velocity;
    }

    /// <summary>
    /// When called, this function sets the walk mode movement
    /// </summary>
    /// <param name="moveDirection">the direction of input</param>
    /// <param name="velocity">the velocity of the rigidbody</param>
    public void SetWalkMovement(Vector2 moveDirection, Vector2 velocity)
    {
        // Get the rigidbody velocity and store it
        velocity = rb.velocity;

        // Add the movement direction and speed to the stored velocity variable
        velocity = moveDirection * speed;

        // Set the rigidbody velocity to the stored velocity variable
        rb.velocity = velocity;
    }

    /// <summary>
    /// When called, this function sets all components needed 
    /// </summary>
    public void SetComponents()
    {
        playerManager = GetComponent<PlayerManager>();
        rb = playerManager.GetComponent<Rigidbody2D>();
        boxCol = playerManager.GetComponent<BoxCollider2D>();
    }
}
