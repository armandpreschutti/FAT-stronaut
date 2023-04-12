using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHubHandler : MonoBehaviour
{
    public GameManager gameManager;
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
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        gameManager.SetPlayer();
    }
    
    /// <summary>
    /// When called, this function sets the player state variables for the ship hub
    /// </summary>
    /// <param name="position"></param>
    public void SetPlayerState(Vector3 position)
    {
        gameManager.playerManager.transform.position = position;
        gameManager.playerManager.jetPackHandler.SetJetInactive();
    }
}
