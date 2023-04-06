using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionHandler : MonoBehaviour
{

    public PlayerManager playerManager;
    public Rigidbody2D rb;
    public BoxCollider2D boxCol;
    public float speed;



    public void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
        boxCol= GetComponent<BoxCollider2D>();
    }

    public void FixedUpdate()
    { 
        SetPlayerMovement(playerManager.playerInput.moveDirection, rb.velocity);
        SetPlayerFacing(playerManager.playerInput.moveHorizontal, rb.velocity);
    }

    public void SetPlayerMovement(Vector2 moveDirection, Vector2 velocity)
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

    public void SetPlayerFacing(float horizontal, Vector2 velocity)
    {
        // Check if the current x value of the rigidbody velocity is less than zero
        if(velocity.x < 0)
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
}
