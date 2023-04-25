using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocomotionHandler : MonoBehaviour
{
    public PlayerManager playerManager;
    public Rigidbody2D rb;
    public BoxCollider2D boxCol;
    public SpriteRenderer spriteRenderer;

    public float speed;
    public float maxSpeed;
    public Vector2 lastVelocity = Vector2.zero;


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
        // Check if the character's velocity has changed
        if (velocity != lastVelocity)
        {
            // Update the character's direction
            if (velocity.x > 0f)
            {
                spriteRenderer.flipX = false; // face right
            }
            else if (velocity.x < 0f)
            {
                spriteRenderer.flipX = true; // face left
            }
        }

        // Store the character's current velocity for the next update
        lastVelocity = velocity;
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
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);

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
        rb.velocity = velocity ;
    }

    /// <summary>
    /// When called, this function sets all components needed 
    /// </summary>
    public void SetComponents()
    {
        playerManager = GetComponent<PlayerManager>();
        rb = playerManager.GetComponent<Rigidbody2D>();
        boxCol = playerManager.GetComponent<BoxCollider2D>();
        spriteRenderer = playerManager.GetComponent<SpriteRenderer>();
    }
}
