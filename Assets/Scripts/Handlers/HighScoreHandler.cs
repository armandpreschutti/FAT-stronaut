using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreHandler : MonoBehaviour
{

    private Coroutine scoreCoroutine;
    public int scoreMultiplier;
    public int highScore;
    public Text highScoreText;
    

    /// <summary>
    /// On enable, this function will be called
    /// </summary>
    public void OnEnable()
    {
        
        ResetScore();
        scoreCoroutine = StartCoroutine(IncreaseScoreCoroutine());
    }

    /// <summary>
    /// On Disable, this function will be called
    /// </summary>
    public void OnDisable()
    {
        StopScoreCoroutine();
        SaveHighScore();
        highScoreText = null;
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
            SetHighScoreText(highScore);
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
    public void ResetScore()
    {
        // Set high score UI to 0
        SetHighScoreText(0);

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
    /// When called, this function sets the value of high score text
    /// </summary>
    /// <param name="value">desired value of high score text</param>
    public void SetHighScoreText(int value)
    {
        if(highScoreText != null)
        {
            highScoreText.GetComponent<Text>().text = value.ToString();
        }

        else
        {
            return;
        }        
    }

    /// <summary>
    /// When called, this function shows the current high score
    /// </summary>
    public void ShowHighScore()
    { 
        SetHighScoreText(PlayerPrefs.GetInt("HighScore"));
    }
}

    

