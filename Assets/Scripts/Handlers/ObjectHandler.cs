using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{

    public Rigidbody2D rb;
    public Collider2D col;
    public PlayerManager target;
    public float speed;
    public float healthValue;
    public Vector2 direction;
    public float lifeTime;
    public float playerIncreaseRate;

    /// <summary>
    /// On awake, this function is called
    /// </summary>
    private void Awake()
    {
        SetComponents();
        Invoke("DestroySelf", lifeTime);        
    }

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
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

            // Increase the size of the player
            collision.gameObject.GetComponent<PlayerManager>().IncreaseSize(playerIncreaseRate);

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
        direction = new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y)- new Vector2(this.transform.position.x, this.transform.position.y);//Random.insideUnitCircle.normalized;

        // Normalize direction
        direction.Normalize();

        // Move rigidbody velocity toward direction with speed
        rb.velocity = direction * speed;
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        target = PlayerManager.GetInstance();
    }

    /// <summary>
    /// When called, this function destroys current gameobject
    /// </summary>
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

}
