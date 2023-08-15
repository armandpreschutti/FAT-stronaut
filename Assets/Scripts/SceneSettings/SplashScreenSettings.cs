using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SplashScreenSettings : MonoBehaviour
{
    public GameManager gameManager;
    public string nextScene = "TitleMenu";
    public float splashDuration;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    private void Start()
    {
        StartSplashScreen(splashDuration);
    }

    /// <summary>
    /// When called, this function start the splash screen logo
    /// </summary>
    /// <param name="duration">duration of the splash screen</param>
    public void StartSplashScreen(float duration)
    {
        Invoke("EndSplashScreen", duration);
    }

    /// <summary>
    /// When called, this function ends the splash screen and continues to menu
    /// </summary>
    public void EndSplashScreen()
    {
        SceneManager.LoadScene(nextScene);
    }

}
