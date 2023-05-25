using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    
    public GameObject shieldText;

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

   

    
    

    

    

    public void ShowShield()
    {
        shieldText.SetActive(true);
        
    }

    
}
