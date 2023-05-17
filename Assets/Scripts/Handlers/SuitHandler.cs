using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;



public class SuitHandler : MonoBehaviour
{
    [Header("Components")]
    public GameManager gameManager;
    public PlayerManager playerManager;
    public GameObject suitPanel;

    [Space]
    public Sprite[] suits;
    public int suitIndex;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
        SetState();
    }

    /// <summary>
    /// When called, this function previews the next suit in the suits array
    /// </summary>
    public void PreviewNextSuit()
    {
        // Check if the current suit is not over the bounds of the suits array
        if (suitIndex < suits.Length - 1)
        {
            // Increment suit index 
            suitIndex++;

            // Set player suit to the new suit index variable
            SetPlayerSuit();
        }
        else
        {
            return;
        }   
    }

    /// <summary>
    /// When called, this function previews the previous suit in the suits array
    /// </summary>
    public void PreviewPreviousSuit()
    {
        // Check if the current suit is not under the bounds of the suits array
        if (suitIndex > 0)
        {
            // Decrement suit index 
            suitIndex--;

            // Set player suit to the new suit index variable
            SetPlayerSuit();
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// When called, this function sets the suit variables on the player instance
    /// </summary>
    public void SetPlayerSuit()
    {
        // Set the players suit ID to the suit index
        playerManager.suitID = suitIndex;

        // Set the player suit to the next suit
        playerManager.GetComponent<SpriteRenderer>().sprite = suits[suitIndex];
    }

    /// <summary>
    /// When callled, this function enables the suit selection menu
    /// </summary>
    public void EnterSuitSelection()
    { 
        suitPanel.SetActive(true);
    }

    /// <summary>
    /// When callled, this function enables the suit selection menu
    /// </summary>
    public void ExitSuitSelection()
    { 
        suitPanel?.SetActive(false);
    }  

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        playerManager = PlayerManager.GetInstance();

    }

    /// <summary>
    /// When called, this function sets the state of  suit handler selection mode
    /// </summary>
    public void SetState()
    {
        suitIndex = playerManager.suitID;
    }

}
