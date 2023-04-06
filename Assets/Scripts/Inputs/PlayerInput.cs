
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveHorizontal;
    public float moveVertical;
    public Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetAxisInput();
    }

    public void GetAxisInput()
    {
        // Get the horizontal axis input
        moveHorizontal = Input.GetAxis("Horizontal");

        // Get the vertical axis input
        moveVertical = Input.GetAxis("Vertical");

        // Get the movement direction
        moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

    }
}
