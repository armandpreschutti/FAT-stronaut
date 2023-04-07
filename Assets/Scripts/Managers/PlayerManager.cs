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
    public bool jetActive;

    private void Awake()
    {
        if (playerInstance == null)
        {
            playerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static PlayerManager GetInstance()
    {
        return playerInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        locomotionHandler= GetComponent<LocomotionHandler>();
        playerInput= GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        boxCol= GetComponent<BoxCollider2D>();
        jetPackParticleSystem = GetComponentInChildren<ParticleSystem>();
        gameManager= FindObjectOfType<GameManager>();
    }

}
