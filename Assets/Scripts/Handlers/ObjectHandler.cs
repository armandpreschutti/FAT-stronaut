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
    public GameObject objectEffect;

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

            // Increase the size of player
            collision.gameObject.GetComponent<PlayerManager>().playerSizeHandler.IncreaseSize(playerIncreaseRate);


            // Play object VFX
            Instantiate(objectEffect, transform.position, Quaternion.identity);

            // Destroy this game object
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// When called, this function sets game object movement to a random direction
    /// </summary>
    public void SetMovementDirection()
    {
        // Set direction of spawned object
        direction = GetPlayerRalativeLocation();

        //Move rigidbody velocity toward direction with speed
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

    /// <summary>
    /// When called, this function returns a Vector 3 that aims towrd player target
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPlayerRalativeLocation()
    {
        Vector3 direction = target.transform.position - transform.position;

        if (direction.x > 14.9)
        {
           direction = new Vector3(1,0,0);
        }
        else if (direction.x < -14.9)
        {
            direction = new Vector3(-1, 0, 0);
        }
        else if(direction.y > 9.9)
        {
            direction = new Vector3(0, 1, 0);
        }
        else
        {
            direction = new Vector3(0, -1, 0);
        }

        return direction;
    }
}
