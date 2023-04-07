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

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        SwitchScene(currentScene);
    }

    // switch scene based on scene constant
    void SwitchScene(int scene)
    {
        switch (scene)
        {
            case splashScreen:
                SceneManager.LoadScene("SplashScreen");
                break;
            case titleMenu:
                SceneManager.LoadScene("TitleMenu");
                break;
            case shipHub:
                SceneManager.LoadScene("ShipHub");
                break;
            case spaceExploration:
                SceneManager.LoadScene("SpaceExploration");
                break;
            default:
                Debug.LogError("Invalid scene index");
                break;
        }
    }

    // example of changing the scene
    public void GoToScene(int newScene)
    {
        currentScene = newScene;
        SwitchScene(currentScene);
    }

    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void PreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + -1);
    }

}
