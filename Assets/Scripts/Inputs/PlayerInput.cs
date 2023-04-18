using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerControls playerControls;
    private InputAction move;
    private InputAction fire;
    public Vector2 moveDirection;
    public float moveHorizontal;
    public float moveVertical;
    public bool disableMovement;

    private void Awake()
    {
        SetComponents();
    }

    private void OnEnable()
    {
        ActivateInput();
    }

    private void OnDisable()
    {
        DeactivateInput();
    }

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
        // Set the movement direction input vector
        moveDirection = move.ReadValue<Vector2>();
    }

    /// <summary>
    /// When called this function disables the player axis input
    /// </summary>
    public void DisableAxisInput()
    {
        moveDirection= Vector2.zero;
    }

    public void ActivateInput()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    public void DeactivateInput()
    {
        move.Disable();
        fire.Disable();
    }

    public void SetComponents()
    {
        playerControls = new PlayerControls();
    }

    private void Fire(InputAction.CallbackContext context)
    {
        
    }
    
}
