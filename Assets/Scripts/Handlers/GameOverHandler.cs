using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerManager playerManager;

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
        playerManager = PlayerManager.GetInstance();
        gameManager.GetComponent<HighScoreHandler>().enabled = false;
        playerManager.GetComponent<SpriteRenderer>().enabled = false;
        playerManager.GetComponent<LocomotionHandler>().enabled = false;
        playerManager.GetComponent<HealthHandler>().enabled = false;
        playerManager.GetComponent<PlayerInput>().enabled = false;
        playerManager.GetComponentInChildren<JetPackHandler>().DestroyAllParticles();
        playerManager.transform.position = Vector3.zero;
        playerManager.rb.velocity = Vector3.zero;
    }
}
