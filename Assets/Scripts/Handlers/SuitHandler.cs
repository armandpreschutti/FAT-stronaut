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
    public UIManager uiManager;
    public SpriteRenderer playerRenderer;
    public Camera previewCamera;

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
        gameManager.playerManager.suitID = suitIndex;

        // Set the player suit to the next suit
        playerRenderer.sprite = suits[suitIndex];
    }

    /// <summary>
    /// When callled, this function enables the suit selection menu
    /// </summary>
    public void EnterSuitSelection()
    {
        // Deactivate enter button
        uiManager.enterButton.SetActive(false);

        // Set player position to preview position
        playerManager.transform.position = this.transform.position;

        // Set selection variables
        SetSelectionVariables(true, new Vector3(this.transform.position.x, this.transform.position.y, -10), 1);

        // Activate selection buttons
        uiManager.SetSelectionButtons(true);
    }

    /// <summary>
    /// When callled, this function enables the suit selection menu
    /// </summary>
    public void ExitSuitSelection()
    {
        // Set selection variables
        SetSelectionVariables(false, new Vector3(0, 0, -10), 2);

        // Deactivate selection buttons
        uiManager.SetSelectionButtons(false);
    }

    

    /// <summary>
    /// When called, this function sets the state of selection variables
    /// </summary>
    /// <param name="canMove">movement state of player instance</param>
    /// <param name="camPosition">position to move camera</param>
    /// <param name="camSize">size of camera</param>
    public void SetSelectionVariables(bool canMove, Vector3 camPosition, int camSize)
    {
        // Set movement state of player instance
        playerManager.playerInput.disableMovement = canMove;

        // Set camera position
        previewCamera.transform.position = camPosition;

        // Set camera size
        previewCamera.orthographicSize = camSize;
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        playerManager = PlayerManager.GetInstance();
        uiManager = UIManager.GetInstance();
        playerRenderer = playerManager.GetComponent<SpriteRenderer>();
        previewCamera = FindObjectOfType<Camera>();
    }

    /// <summary>
    /// When called, this function sets the state of  suit handler selection mode
    /// </summary>
    public void SetState()
    {
        suitIndex = playerManager.suitID;
        uiManager.SetSelectionButtons(false);
        uiManager.enterButton.SetActive(false);
    }

    /// <summary>
    /// Called when object enters trigger zone
    /// </summary>
    /// <param name="collision">object detected in trigger zone</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object is player
        if (collision.tag == "Player")
        {
            // Activate enter button
            gameManager.uiManager.enterButton.SetActive(true);
        }

        else
        {
            return;
        }
    }

    /// <summary>
    /// Called when object exits trigger zone
    /// </summary>
    /// <param name="collision">object detected in trigger zone</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the object is player
        if (collision.tag == "Player")
        {
            // Deactivate enter button
            gameManager.uiManager.enterButton.SetActive(false);
        }

        else
        {
            return;
        }
    }

}
