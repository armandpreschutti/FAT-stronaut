
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerManager playerManager;

    public Vector2 moveDirection;
    public float moveHorizontal;
    public float moveVertical;
    public bool disableMovement;


    /// <summary>
    /// Once every frame, this function is called
    /// </summary>
    void Update()
    {
        SetPlayerAxisInputState();
    }

    /// <summary>
    /// When called, this function sets the state of the player axis input
    /// </summary>
    public void SetPlayerAxisInputState()
    {
        // Check if the player axis input is disabled
        if (!disableMovement)
        {
            EnableAxisInput();
        }
        else
        {
            DisableAxisInput();
        }
    }

    /// <summary>
    /// When called, this function gets the player axis input and sets them to a correlating variable
    /// </summary>
    public void EnableAxisInput()
    {
        // Set the horizontal axis input variable
        moveHorizontal = Input.GetAxis("Horizontal");

        // Set the vertical axis input variable
        moveVertical = Input.GetAxis("Vertical");

        // Set the movement direction input vector
        moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    /// <summary>
    /// When called this function disables the player axis input
    /// </summary>
    public void DisableAxisInput()
    {
        moveDirection= Vector2.zero;
    }

}
