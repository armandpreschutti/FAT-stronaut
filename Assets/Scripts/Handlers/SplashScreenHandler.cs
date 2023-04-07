using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using TMPro;
public class SplashScreenHandler : MonoBehaviour
{
    public GameManager gameManager;
    public float splashDuration;

    private void Start()
    {
        gameManager = GameManager.GetInstance();
        StartSplashScreen(splashDuration);
        
    }
    public void StartSplashScreen(float duration)
    {
        Invoke("EndSplashScreen", duration);
    }

    public void EndSplashScreen()
    {
        gameManager.levelManager.GoToScene(1);
    }
   
}
