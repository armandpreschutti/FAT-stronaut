using DG.Tweening;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Options;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public enum ObjectType
    {
        Food,
        Obstacle,
        Suit
    }

    public ObjectType objectType;
    public Rigidbody2D rb;
    public Collider2D col;
    public float speed;
    public float healthValue;
    public int damageValue;
    public float playerIncreaseRate;
    public GameObject objectEffect;
    public AudioClip objectSFX;
    public Sprite suitSprite;
    public int suitOptions;


    /// <summary>
    /// On awake, this function is called
    /// </summary>
    private void Awake()
    {
        SetComponents();    
    }

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        //Move rigidbody velocity toward direction with speed
        rb.velocity = new Vector3(-1, 0, 0) * speed;
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
            collision.gameObject.GetComponent<PlayerSizeHandler>().IncreaseSize(playerIncreaseRate);
            // Play object VFX
            Instantiate(objectEffect, transform.position, Quaternion.identity);
            // Play object SFX
            collision.GetComponent<SFXHandler>().PlaySFX(objectSFX);

            switch (objectType)
            {
                case ObjectType.Food:
                    // Apply health to player
                    collision.gameObject.GetComponent<HealthHandler>().ChangeHealth(healthValue);
                    // Play chew animation
                    collision.transform.DOPunchScale(new Vector3(.25f, .25f, .25f), .5f);
                    break;
                case ObjectType.Obstacle:
                    // Apply damage to player
                    collision.gameObject.GetComponent<ShieldHandler>().DamageShield(damageValue);
                    // Play crash animation
                    collision.transform.DOShakePosition(.5f, new Vector3(0, .15f, .15f), 10, 0);
                    break;
                case ObjectType.Suit:
                    GameManager.GetInstance().GetComponent<SuitHandler>().UnlockSuit(suitSprite);
                    Destroy(this.gameObject);
                    break;
                default:
                    break;
            }
            Destroy(this.gameObject);
          
        }
    }


    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        switch(objectType)
        {
            case ObjectType.Suit:
                suitOptions = GameManager.GetInstance().GetComponent<SuitHandler>().lockedSuits.Count;
                suitSprite = GameManager.GetInstance().GetComponent<SuitHandler>().lockedSuits[Random.Range(0, suitOptions)];
                this.GetComponent<SpriteRenderer>().sprite = suitSprite;
                break;
            default:
                break;
        }
    }




}
