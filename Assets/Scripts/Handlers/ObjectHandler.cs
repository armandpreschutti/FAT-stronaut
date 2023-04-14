using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{

    public Rigidbody2D rb;
    public Collider2D boxcol;
    public float speed;
    public float healthValue;
    public Vector2 direction;
    public float ricochetForce = 10f;
    public float ricochetDelay = 0.5f;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    private void Start()
    {
        SetComponentes();
        SetMovementDirection();
    }

    /// <summary>
    /// This function is called whenever a collider enters the trigger area of collider
    /// </summary>
    /// <param name="collision">collider within trigger area</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider is player
        if (collision.gameObject.tag == "Player")
        {
            // Apply health or damage to player
            collision.gameObject.GetComponent<HealthHandler>().ChangeHealth(healthValue);

            // Destroy this game object
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// When called, this function sets game object movement to a random direction
    /// </summary>
    public void SetMovementDirection()
    {
        // Set direction to a random direction
        direction = Random.insideUnitCircle.normalized;

        // Normalize direction
        direction.Normalize();

        // Move rigidbody velocity toward direction with speed
        rb.velocity = direction * speed;
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponentes()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcol = GetComponent<Collider2D>();
    }

}
