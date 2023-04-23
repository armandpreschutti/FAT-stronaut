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

    /// <summary>
    /// On enable, this function will be called
    /// </summary>
    public void OnEnable()
    {
        SetComponents();
        ResetHighScore();
        scoreCoroutine = StartCoroutine(IncreaseScoreCoroutine());
    }

    /// <summary>
    /// On Disable, this function will be called
    /// </summary>
    public void OnDisable()
    {
        StopScoreCoroutine();
        SaveHighScore();
    }
   
    /// <summary>
    /// When called, this function increases current score
    /// </summary>
    /// <param name="multiplier">the amount to add to current score</param>
    void IncreaseScore(int multiplier)
    {
        // check if script is enabled
        if (this.enabled)
        {
            // add multiplier to high score
            highScore = highScore + multiplier;

            // update the high score UI
            uiManager.SetHighScoreText(highScore);
        }
    }

    /// <summary>
    /// When called, this coroutine waits 1 second, then increases the current score until script is disabled
    /// </summary>
    /// <returns></returns>
    IEnumerator IncreaseScoreCoroutine()
    {
        // Check if coroutine is true
        while (true)
        {
            // Wait 1 second
            yield return new WaitForSeconds(1f);

            // Increase current score
            IncreaseScore(scoreMultiplier);
        }
    }

    /// <summary>
    /// When called, this function stops the score tracking coroutine
    /// </summary>
    private void StopScoreCoroutine()
    {
        // Check if coroutine is no longer active
        if (scoreCoroutine != null)
        {
            // Stop high score coroutine
            StopCoroutine(scoreCoroutine);

            // Set coroutine to null
            scoreCoroutine = null;
        }
    }

    /// <summary>
    /// When called, this function resets high score for session
    /// </summary>
    public void ResetHighScore()
    {
        // Set high score UI to 0
        uiManager.SetHighScoreText(0);

        // Set high score to 0
        highScore= 0;
    }

    /// <summary>
    /// When called, this function checks for new hgih score and saves it
    /// </summary>
    public void SaveHighScore()
    {
        // Check if session score is greater than high score
        if(highScore > PlayerPrefs.GetInt("HighScore"))
        {
            // Save session score as new high score
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
        uiManager = UIManager.GetInstance();
    }
}

    

