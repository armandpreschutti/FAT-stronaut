using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject highScoreText;
    public GameObject healthSlider;

    [Header("Suit Selection Buttons")]
    public GameObject enterButton;
    public GameObject nextSuitButton;
    public GameObject prevSuitButton;
    public GameObject exitButton;

    private static UIManager uiInstance;

    /// <summary>
    /// On awake, this function sets this game object to a ui manager singleton
    /// </summary
    private void Awake()
    {
        // Check if this game object already exists
        if (uiInstance == null)
        {
            // Set this to game manager singleton
            uiInstance = this;

            // Don't destroy between scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy this game object
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// When called, this function returns the current singleton instance of the ui manager
    /// </summary>
    /// <returns>game manager instance</returns>
    public static UIManager GetInstance()
    {
        return uiInstance;
    }

    /// <summary>
    /// When called, this function shows the current high score
    /// </summary>
    public void ShowHighScore()
    {
        ActivateHighScoreText(true);
        SetHighScoreText(PlayerPrefs.GetInt("HighScore"));
    }

    /// <summary>
    /// When called, this function sets the state of selection buttons
    /// </summary>
    /// <param name="buttonState">the desired state of selection buttons</param>
    public void SetSelectionButtons(bool buttonState)
    {
        prevSuitButton.SetActive(buttonState);
        nextSuitButton.SetActive(buttonState);
        exitButton.SetActive(buttonState);
    }

    /// <summary>
    /// When called, this function sets the state of high score text
    /// </summary>
    /// <param name="state">desired state of high score text</param>
    public void ActivateHighScoreText(bool state)
    {
        highScoreText.SetActive(state);
    }

    /// <summary>
    /// When called, this function sets the value of high score text
    /// </summary>
    /// <param name="value">desired value of high score text</param>
    public void SetHighScoreText(int value)
    {
        highScoreText.GetComponent<Text>().text = value.ToString();
    }

    /// <summary>
    /// When called, this function sets the state of helath bar
    /// </summary>
    /// <param name="state"></param>
    public void ActivateHealthBar(bool state)
    {
        healthSlider.SetActive(state);
    }

    /// <summary>
    /// When called, this function sets health slider value to current health
    /// </summary>
    /// /// <param name="value">desired value of health bar</param>
    public void SetHealthBar(float health)
    {
        healthSlider.GetComponent<Slider>().value = health;
    }

    
}
