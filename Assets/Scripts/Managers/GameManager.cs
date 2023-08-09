using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("Components")]
    private static GameManager gameInstance;

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


}
