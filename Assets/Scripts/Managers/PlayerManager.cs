using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    

    [Header("Components")]
    public GameManager gameManager;
    public Rigidbody2D rb;
    public BoxCollider2D boxCol;
    public LocomotionHandler locomotionHandler;
    public PlayerInput playerInput;
    public ParticleSystem jetPackParticleSystem;

    public HealthHandler healthHandler;
    public PlayerSizeHandler playerSizeHandler;

    [Header("Variables")]
    public int suitID;
    public bool isExploring;
    public bool isDead;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    void Start()
    {
        SetComponents();
    }

    /// <summary>
    /// When called, this function sets all components needed by game manager
    /// </summary>
    public void SetComponents()
    {
        locomotionHandler = GetComponent<LocomotionHandler>();
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        jetPackParticleSystem = GetComponentInChildren<ParticleSystem>();
        gameManager = GameManager.GetInstance();
        healthHandler = FindObjectOfType<HealthHandler>();
        playerSizeHandler = GetComponent<PlayerSizeHandler>();
    }   
}
