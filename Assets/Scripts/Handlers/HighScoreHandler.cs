using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighScoreHandler : MonoBehaviour
{
    public GameManager gameManager;
    public UIManager uiManager;
    public int highScore;
    private Coroutine scoreCoroutine;
    public int scoreMultiplier;

    public void OnEnable()
    {
        SetComponents();
        ResetHighScore();
        scoreCoroutine = StartCoroutine(IncreaseScoreCoroutine());
    }
    public void OnDisable()
    {
        StopScoreCoroutine();
        SaveHighScore();
    }
   
    void IncreaseScore(int multiplier)
    {
        if (this.enabled)
        {
            highScore = highScore + multiplier;
            uiManager.UpdateHighScoreText(highScore);
        }

    }

    IEnumerator IncreaseScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            IncreaseScore(scoreMultiplier);
        }
    }

    private void StopScoreCoroutine()
    {
        if (scoreCoroutine != null)
        {
            StopCoroutine(scoreCoroutine);
            scoreCoroutine = null;
        }
    }
    public void ResetHighScore()
    {
        uiManager.UpdateHighScoreText(0);
        highScore= 0;
    }
    public void SaveHighScore()
    {
        if(highScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        else
        {
            return;
        }
    }
    
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        uiManager = UIManager.GetInstance();
    }
}

    

