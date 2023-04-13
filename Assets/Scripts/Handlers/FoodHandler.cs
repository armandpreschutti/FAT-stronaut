using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D boxcol;
    public ParticleSystem foodParticles;
    public float healthValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcol= GetComponent<BoxCollider2D>();
        foodParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthHandler>().ChangeHealth(healthValue);
            Destroy(this.gameObject);
        }
        
    }
}
