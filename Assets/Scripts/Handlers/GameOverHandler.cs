using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    public GameManager gameManager;

    public void Start()
    {
        SetComponents();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("SpaceExploration");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        gameManager.GetComponent<HighScoreHandler>().enabled = false;
    }
}
