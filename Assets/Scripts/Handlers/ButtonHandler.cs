using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject suitHandler;
    public GameManager gameManager;
    public string buttonType;

    /// <summary>
    /// On enable, this function is called
    /// </summary>
    public void OnEnable()
    {
        SetComponents();
    }

    /// <summary>
    /// When called, this function checks the type of button it is, then performs a corresponding function
    /// </summary>
    public void OnClickMyButton()
    {
        // check button type
        switch(buttonType)
        {

            /*// Preview the previous suit
            case "PreviousSuitButton":
                suitHandler.GetComponent<SuitHandler>().PreviewPreviousSuit();
                return;

            // Preview the next suit
            case "NextSuitButton":
                suitHandler.GetComponent<SuitHandler>().PreviewNextSuit();
                return;*/

            // Reset High Score
            case "ResetButton":
                PlayerPrefs.SetInt("HighScore", 0);
                return;

            // Do nothing
            default:
                Debug.Log("No Value");
                break;
        }
    }

    /// <summary>
    /// When called, this function sets the state of  suit handler selection mode
    /// </summary>
    public void SetComponents()
    {
        suitHandler = GameObject.Find("SuitManager");
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnClickMyButton);
    }
}
