using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerManager playerManager;
    public GameObject settingsMenu;
    public Text highScoreText;


    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();
        SetPlayerState();   
    }

    /// <summary>
    /// When called, this function starts game
    /// </summary>
    public void StartSpaceExploration()
    {
        gameManager.levelManager.SwitchScene(3);
    }

    /// <summary>
    /// When called, this function starts game
    /// </summary>
    public void StartPractice()
    {
        gameManager.levelManager.SwitchScene(4);
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
        playerManager = PlayerManager.GetInstance();
        gameManager.GetComponent<HighScoreHandler>().enabled = false;
        DisplayHighScore();
    }

    public void SetPlayerState()
    {
        playerManager.GetComponent<SpriteRenderer>().enabled = false;
        playerManager.GetComponent<LocomotionHandler>().enabled = false;
        playerManager.GetComponent<HealthHandler>().enabled = false;
        playerManager.GetComponent<PlayerInput>().enabled = false;
        playerManager.GetComponentInChildren<JetPackHandler>().DestroyAllParticles();
        playerManager.transform.position = Vector3.zero;
        playerManager.rb.velocity = Vector3.zero;
    }

    public void DisplayHighScore()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
