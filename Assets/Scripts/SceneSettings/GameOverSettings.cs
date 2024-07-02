using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class GameOverSettings : MonoBehaviour
{

    public string mainMenuScene = "MainMenu";
    public string replayScene = "SpaceExploration";
   
    public void ReplayGame()
    {
        SceneManager.LoadScene(replayScene);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }


}
