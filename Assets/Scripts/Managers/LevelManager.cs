using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;

    const int splashScreen = 0;
    const int titleMenu = 1;
    const int shipHub = 2;
    const int spaceExploration = 3;
    public int currentScene = splashScreen;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
        //SwitchScene(currentScene);
    }

    /// <summary>
    /// When called, this function takes an integer and switches the scene to the correlating case number
    /// </summary>
    /// <param name="scene">destination scene</param>
    public void SwitchScene(int scene)
    {
        // Check the integer passed through parameter
        switch (scene)
        {
            // Switch to Splash Screen scene
            case splashScreen:
                SceneManager.LoadScene("SplashScreen_0.3");
                break;

            // Switch to Title Menu scene
            case titleMenu:
                SceneManager.LoadScene("TitleMenu_0.3");
                break;

            // Swtich to Ship Hub scene
            case shipHub:
                SceneManager.LoadScene("ShipHub_0.3");
                break;

            // Switch to Space Exploration scene
            case spaceExploration:
                SceneManager.LoadScene("SpaceExploration_0.3");
                break;

            // Do nothing if parameter is out of scope
            default:
                break;
        }
    }

    /// <summary>
    /// When called, this function takes and integer then calls the "SwitchScene" function using the "newScene" parameter
    /// </summary>
    /// <param name="newScene"destination scene></param>
    public void GoToScene(int newScene)
    {
        // Set the current scene to the parameter scene
        currentScene = newScene;

        // Set the scene to the current scene
        SwitchScene(currentScene);
    }

    /// <summary>
    /// When called, this function switch to the next scene in build 
    /// </summary>
    public void NextScene()
    {
        // Create and set the current scene index variable to the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene after current index variable
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    /// <summary>
    /// When called, this function switch to the previous in build
    /// </summary>
    public void PreviousScene()
    {
        // Create and set the current scene index variable to the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the previous scene before the current index variable
        SceneManager.LoadScene(currentSceneIndex + -1);
    }

    /// <summary>
    /// When called, this function sets all components needed 
    /// </summary>
    public void SetComponents()
    {
        gameManager = GetComponent<GameManager>();
    }


}
