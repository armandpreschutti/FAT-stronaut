using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager gameInstance;
    public LevelManager levelManager;
    public PlayerManager playerManager;


    //public bool debugMode;

    /// <summary>
    /// On awake, this function sets this game object to a game manager singleton
    /// </summary
    private void Awake()
    {
        // Check if this game object already exists
        if (gameInstance == null)
        {
            // Set this to game manager singleton
            gameInstance = this;

            // Don't destroy between scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy this game object
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// When called, this function returns the current singleton instance of the game manager
    /// </summary>
    /// <returns>game manager instance</returns>
    public static GameManager GetInstance()
    {
        return gameInstance;
    }

    /// <summary>
    /// On start, this function is called
    /// </summary>
    private void Start()
    {
        SetComponents();
    }

    /// <summary>
    /// When called, this function sets the player variable in game manager
    /// </summary>
    /// <param name="playerManager"></param>
    public void SetPlayer()
    {
        playerManager = PlayerManager.GetInstance();
    }

    /// <summary>
    /// When called, this function sets all components needed by game manager
    /// </summary>
    public void SetComponents()
    {
        levelManager = GetComponent<LevelManager>();
        SetPlayer();
    }

   /* /// <summary>
    /// When called, this function sets debug mode for the game manager
    /// </summary>
    /// <param name="debug">debug mode boolean</param>
    public void SetDebugMode(bool debug)
    {
        // Check if debug mode is activated
        if (debug)
        {
            // Check if player presses positive button
            if (Input.GetButtonDown("Fire1"))
            {
                // Go to the next scene in build
                levelManager.NextScene();
            }

            // Check if player presses negative button
            if (Input.GetButtonDown("Fire2"))
            {
                // Go to the previous scene in build
                levelManager.PreviousScene();
            }
        }

        // Check if debug mode is not activated
        else
        {
            // Do nothing
            return;
        }
    }*/
}
