using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerInstance;
    public GameManager gameManager;
    public Rigidbody2D rb;
    public BoxCollider2D boxCol;
    public LocomotionHandler locomotionHandler;
    public PlayerInput playerInput;
    public ParticleSystem jetPackParticleSystem;
    public JetPackHandler jetPackHandler;


    

    /// <summary>
    /// On awake, this function sets this game object to a player manager singleton
    /// </summary
    private void Awake()
    {
        // Check if this game object already exists
        if (playerInstance == null)
        {
            // Set this to player manager singleton
            playerInstance = this;

            // Don't destroy between scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy this game object
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// When called, this function returns the current singleton instance of the player manager
    /// </summary>
    /// <returns>player manager instance</returns>
    public static PlayerManager GetInstance()
    {
        return playerInstance;
    }

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
        gameManager = FindObjectOfType<GameManager>();
        jetPackHandler = FindObjectOfType<JetPackHandler>();
    }
}
