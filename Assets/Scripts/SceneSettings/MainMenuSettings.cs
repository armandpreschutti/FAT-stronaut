using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSettings : MonoBehaviour
{
    public GameManager gameManager;

    
    public string nextScene = "SpaceExploration";
    public Text highScoreText;
    public Rigidbody2D playerRb;
    public float floatSpeed = 2f;
    public float maxX = 5f;
    public float maxY = 5f;
    public EventSystem eventSystem;
    public GameObject firstSuitSelectionButton;
    public GameObject firstMenuSelectionButton;
    public GameObject firstSettingsSelectionButton;
    public GameObject menuPanel;
    public GameObject suitsPanel;

    public void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        GameObject.Find("Preview").GetComponent<SpriteRenderer>().sprite = GameManager.GetInstance().currentSuit;
        StartCoroutine(PreviewFloat());
    }

   

    public void StartSpaceExploration()
    {
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator PreviewFloat()
    {
        Debug.Log("Function Called");
        // Generate random direction
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        

        // Clamp position within bounds
        float clampedX = Mathf.Clamp(playerRb.transform.position.x, -maxX, maxX);
        float clampedY = Mathf.Clamp(playerRb.transform.position.y, -maxY, maxY);

        // Update the object's position
        playerRb.AddForce(randomDirection * floatSpeed);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Delay Called");
        StartCoroutine(PreviewFloat());
        Debug.Log("RepeatCalled");
    }

    public void SetSuitSelectionUI()
    {
        GameObject.Find("Camera").transform.position = new Vector3(1, 0, -20);
        menuPanel.SetActive(false);
        suitsPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(firstSuitSelectionButton);
        
    }
    public void SetMenuSelectionUI()
    {
        GameObject.Find("Camera").transform.position = new Vector3(0, -1, -30);
        menuPanel.SetActive(true);
        suitsPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(firstMenuSelectionButton);
    }


}
