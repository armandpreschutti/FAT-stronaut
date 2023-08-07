using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("Components")]
    private static GameManager gameInstance;
    public PlayerManager playerManager;


    [Header("LevelManagement")]
    const int splashScreen = 0;
    const int titleMenu = 1;
    const int mainMenu = 2;
    const int spaceExploration = 3;
    const int gameOver = 4;
    public int currentScene = splashScreen;

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
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
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
                SceneManager.LoadScene("SplashScreen");
                break;

            // Switch to Title Menu scene
            case titleMenu:
                SceneManager.LoadScene("TitleMenu");
                break;

            // Switch to Title Menu scene
            case mainMenu:
                SceneManager.LoadScene("MainMenu");
                break;

            // Switch to Space Exploration scene
            case spaceExploration:
                SceneManager.LoadScene("SpaceExploration");
                break;

            // Switch to Game Over scene
            case gameOver:
                SceneManager.LoadScene("GameOver");
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
    /// When called, this function sets all components needed by game manager
    /// </summary>
    public void SetComponents()
    {

    }
}
