using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour
{
    public GameManager gameManager;

    
    public string nextScene = "SpaceExploration";
    public Text highScoreText;


    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    /// <summary>
    /// When called, this function starts game
    /// </summary>
    public void StartSpaceExploration()
    {
        SceneManager.LoadScene(nextScene);
    }

}
