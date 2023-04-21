using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHubHandler : MonoBehaviour
{
    public GameManager gameManager;
    public Transform startLocation;
    public Text highScoreText;
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
        gameManager.playerManager.isExploring = false;

        // Set player position to desired position
        gameManager.playerManager.transform.position = position;

        // Deactivate player jet system
        gameManager.playerManager.jetPackHandler.enabled = false;

        // Deactivate health system
        gameManager.playerManager.healthHandler.enabled = false;

        gameManager.playerManager.ResetSize();
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        gameManager.SetPlayer();
        gameManager.GetComponent<HighScoreHandler>().enabled = false;
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        
    }
}
