using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public GameManager gameManager;
    public BoxCollider2D boxCol;
    public int sceneDestination;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
    }

    /// <summary>
    /// When called, this function sets all components needed by game manager
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
    }

    /// <summary>
    /// When object enters trigger zone, this function is called
    /// </summary>
    /// <param name="collision">the object that passes through trigger</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Leah is a sexy bitch, fuck that bitch
        // and also, check if the collsion has a player tag
        if (collision.tag == "Player")
        {
            // Travel through door
            SetTwoWayDoor(sceneDestination);
        }
    }

    /// <summary>
    /// When called, this function
    /// </summary>
    public void SetTwoWayDoor(int destination)
    {
        // Load destination scene of the door
        gameManager.levelManager.SwitchScene(destination);
    }

}
