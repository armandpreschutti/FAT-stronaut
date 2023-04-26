using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHubHandler : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerManager playerManager;
    public UIManager uiManager;
    public CameraManager cameraManager;

    public Transform startLocation;
        
    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
        SetPlayerState(startLocation.transform.position);
    }
    
    /// <summary>
    /// When called, this function sets the player state variables for the ship hub
    /// </summary>
    /// <param name="position"></param>
    public void SetPlayerState(Vector3 position)
    {
        // Set player state
        PlayerManager.GetInstance().isExploring = false;

        // Set player position to desired position
        playerManager.transform.position = position;

        // Deactivate player jet system
        playerManager.jetPackHandler.enabled = false;

        // Deactivate health system
        playerManager.healthHandler.enabled = false;

        // Reset player size
        playerManager.ResetSize();

        // Destroy all curently running particles
        playerManager.jetPackHandler.DestroyAllParticles();
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        playerManager = PlayerManager.GetInstance();
        uiManager = UIManager.GetInstance();
        cameraManager = CameraManager.GetInstance();
        cameraManager.FindCamera("Camera");
        //gameManager.SetPlayer();
        gameManager.GetComponent<HighScoreHandler>().enabled = false;
        uiManager.ShowHighScore();


    }
}
