using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreHandler : MonoBehaviour
{
    public int highScore;
    public Text highScoreText;
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
            highScoreText.text = highScore.ToString();
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
    public void ShowHighScore()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    public void SetComponents()
    {
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();
    }
}

    

