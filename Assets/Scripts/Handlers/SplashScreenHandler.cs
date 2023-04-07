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
        gameManager= FindObjectOfType<GameManager>();

        Invoke("EndSplashScreen", splashDuration);
    }

    public void EndSplashScreen()
    {
        gameManager.levelManager.NextScene();
    }
   
}
