using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LocomotionHandler : MonoBehaviour
{

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
        Movement(GetComponent<PlayerInput>().moveDirection, rb.velocity);
    }

    /// <summary>
    /// When called, this function sets the jet mode movement
    /// </summary>
    /// <param name="moveDirection">the direction of input</param>
    /// <param name="velocity">the velocity of the rigidbody</param>
    public void Movement(Vector2 moveDirection, Vector2 velocity)
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
    /// When called, this function sets all components needed 
    /// </summary>
    public void SetComponents()
    {

        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
