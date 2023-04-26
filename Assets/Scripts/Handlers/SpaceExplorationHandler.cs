using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceExplorationHandler : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerManager playerManager;
    public CameraManager cameraManager;
    public Transform startLocation;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
        SetPlayerState(startLocation.transform.position);
        StartTrackingScore();
    }

    /// <summary>
    /// When called, this function sets the space exploration state of the player
    /// </summary>
    /// <param name="position"></param>
    public void SetPlayerState(Vector3 position)
    {
        // Set player state
        playerManager.isExploring = true;

        // Set player position to desired position
        playerManager.transform.position = position;

        // Activate player jet system
        playerManager.jetPackHandler.enabled= true;

        // Activate health system
        playerManager.healthHandler.enabled = true;
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        playerManager = PlayerManager.GetInstance();
        cameraManager = CameraManager.GetInstance();
        cameraManager.FindCamera("Camera");
        cameraManager.SetCameraTarget(playerManager.transform);
        
    }

    /// <summary>
    /// Wehn called, this function starts tracking current score
    /// </summary>
    public void StartTrackingScore()
    {
        gameManager.GetComponent<HighScoreHandler>().enabled= true;
       
    }

}
