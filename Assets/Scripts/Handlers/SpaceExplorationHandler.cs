using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SpaceExplorationHandler : MonoBehaviour
{
    public GameManager gameManager;
    public Transform startLocation;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    void Start()
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

    public void SetPlayerState(Vector3 position)
    {
        gameManager.playerManager.transform.position = position;
        gameManager.playerManager.jetPackHandler.SetJetActive();
    }
}
