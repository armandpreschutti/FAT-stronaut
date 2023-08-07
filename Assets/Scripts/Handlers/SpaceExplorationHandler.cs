using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class SpaceExplorationHandler : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerManager playerManager;
    public PlayableDirector playableDirector;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
        SetPlayerState();
    }

    /// <summary>
    /// When called, this function sets the space exploration state of the player
    /// </summary>
    /// <param name="position"></param>
    public void SetPlayerState()
    {
        // Set player state
        playerManager.isExploring = true;

        // Set player position to desired position
        playerManager.transform.position = Vector3.zero;

        // Reset player scale
        playerManager.transform.localScale = Vector3.one;

        // Play jet particles 
        playerManager.GetComponentInChildren<ParticleSystem>().Play();

        // Activate health system
        playerManager.healthHandler.enabled = true;

        // Activate shield system

        playerManager.GetComponent<ShieldHandler>().enabled= true;

        // Activate sprite renderer
        playerManager.GetComponent<SpriteRenderer>().enabled = true;

        // Activate player input
        playerManager.playerInput.enabled = true;

        // Activate player locomotion
        playerManager.locomotionHandler.enabled = true;
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();    
        gameManager.GetComponent<HighScoreHandler>().enabled = true;
    }
    public void GameOver()
    {
        playableDirector.Play();
        playerManager.GetComponent<HealthHandler>().enabled = false;
        playerManager.GetComponent<ShieldHandler>().enabled = false;
    }
    public void SendToGameOverMenu()
    {
        SceneManager.LoadScene("GameOver");
    }

}
