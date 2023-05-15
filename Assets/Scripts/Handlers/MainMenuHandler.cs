using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public GameManager gameManager;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
    }

    /// <summary>
    /// When called, this function starts game
    /// </summary>
    public void StartSpaceExploration()
    {
        gameManager.levelManager.SwitchScene(3);
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
    }
}
