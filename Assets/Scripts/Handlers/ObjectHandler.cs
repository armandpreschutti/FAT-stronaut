using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{

    public Rigidbody2D rb;
    public Collider2D col;
    public float speed;
    public float healthValue;
    public int damageValue;
    public Vector2 direction;
    public float lifeTime;
    public float playerIncreaseRate;
    public GameObject objectEffect;
    public bool isFood;
    public bool isObstacle;
    public AudioClip objectSFX;

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
            // Increase the size of player
            collision.gameObject.GetComponent<PlayerManager>().playerSizeHandler.IncreaseSize(playerIncreaseRate);

            // Play object VFX
            Instantiate(objectEffect, transform.position, Quaternion.identity);

            if (isFood)
            {
                // Apply health to player
                collision.gameObject.GetComponent<HealthHandler>().ChangeHealth(healthValue);

                // Play chew animation
                collision.transform.DOPunchScale(new Vector3(.25f,.25f,.25f), .5f);
            }

            else if(isObstacle)
            {
                // Apply damage to player
                collision.gameObject.GetComponent<ShieldHandler>().DamageShield(damageValue);

                // Play crash animation
                collision.transform.DOShakePosition(.5f, new Vector3(0,.15f,.15f), 10, 0);
            }

            else
            {
                return;
            }

            // Play object SFX
            collision.GetComponent<SFXHandler>().PlaySFX(objectSFX);

            // Destroy this game object
            DestroySelf();
        }
    }

    /// <summary>
    /// When called, this function sets game object movement to a random direction
    /// </summary>
    public void SetMovementDirection()
    {
        // Set direction of spawned objectS
        direction = new Vector3(-1, 0, 0);

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
    }

    /// <summary>
    /// When called, this function destroys current gameobject
    /// </summary>
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }


}
