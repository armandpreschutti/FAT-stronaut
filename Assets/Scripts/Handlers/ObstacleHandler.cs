using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D boxcol;
    public ParticleSystem foodParticles;
    public float damageValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcol = GetComponent<BoxCollider2D>();
        foodParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthHandler>().ChangeHealth(damageValue);
            Destroy(this.gameObject);
        }

    }
}
