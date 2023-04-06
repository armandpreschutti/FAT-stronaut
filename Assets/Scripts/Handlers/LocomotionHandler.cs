using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionHandler : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D rb;
    public BoxCollider2D boxCol;
    public float speed;
    public float vel;


    public void Start()
    {
        playerInput= GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        boxCol= GetComponent<BoxCollider2D>();
    }

    public void FixedUpdate()
    {
        PlayerMovement(playerInput.moveDirection);
    }

    public void PlayerMovement(Vector2 moveDirection)
    {
        /*rb.AddForce(moveDirection * speed);
        Debug.Log(rb.velocity.magnitude);
        if(rb.velocity.magnitude > 2) 
        {
            rb.AddForce(moveDirection * speed);
        }
        else
        {
            rb.AddForce(moveDirection);
        }*/
        vel = rb.velocity.magnitude;
        Debug.Log(vel);

        Vector2 velocity = rb.velocity;
        velocity += moveDirection * speed * Time.fixedDeltaTime;
        velocity = Vector2.ClampMagnitude(velocity, speed);

        rb.velocity = velocity;

    }
}
