using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject settingsMenu;
    public Text highScoreText;


    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
        
    }

    /// <summary>
    /// When called, this function starts game
    /// </summary>
    public void StartSpaceExploration()
    {
        gameManager.SwitchScene(3);
    }

    public void EnableSettings()
    {
        settingsMenu.SetActive(true);
    }
    

    public void DisableSettings()
    {
        settingsMenu.SetActive(false);
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        gameManager.GetComponent<HighScoreHandler>().enabled = false;
        DisplayHighScore();
    }

    public void DisplayHighScore()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
