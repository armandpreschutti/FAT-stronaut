using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using TMPro;
public class SplashScreenHandler : MonoBehaviour
{
    public GameManager gameManager;

    public float splashDuration;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    private void Start()
    {
        SetComponents();
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
        gameManager.GoToScene(1);
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        gameManager = GameManager.GetInstance();
    }

}
