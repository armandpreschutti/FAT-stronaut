using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHubHandler : MonoBehaviour
{
    public GameManager gameManager;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    void Start()
    {
        SetComponents();
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
    }
}
