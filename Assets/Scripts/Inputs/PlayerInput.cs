
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerManager playerManager;

    public Vector2 moveDirection;
    public float moveHorizontal;
    public float moveVertical;


    /// <summary>
    /// Once every frame, this function is called
    /// </summary>
    void Update()
    {
        GetAxisInput();
    }

    /// <summary>
    /// When called, this function gets the player axis inputs and sets them to a correlating variable
    /// </summary>
    public void GetAxisInput()
    {
        // Set the horizontal axis input variable
        moveHorizontal = Input.GetAxis("Horizontal");

        // Set the vertical axis input variable
        moveVertical = Input.GetAxis("Vertical");

        // Set the movement direction input vector
        moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;
    }

}
