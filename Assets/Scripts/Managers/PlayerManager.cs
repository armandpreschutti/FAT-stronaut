using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D boxCol;
    public LocomotionHandler locomotionHandler;
    public PlayerInput playerInput;
    public ParticleSystem jetPackParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        locomotionHandler= GetComponent<LocomotionHandler>();
        playerInput= GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        boxCol= GetComponent<BoxCollider2D>();
        jetPackParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
