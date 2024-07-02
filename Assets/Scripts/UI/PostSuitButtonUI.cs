using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostSuitButtonUI : MonoBehaviour
{
    public SpriteRenderer suitPreview;
    public Sprite unlockSprite;
    public Image icon;
    public bool isUnlocked;
    public int index;

    void Start()
    {
        if (GameManager.GetInstance().sessionUnlocked.Capacity < index +1)
        {
            gameObject.SetActive(false);
        }
       
        else
        {
            unlockSprite = GameManager.GetInstance().sessionUnlocked[index];
            icon.sprite = unlockSprite;
        }

        suitPreview = GameObject.Find("Preview").GetComponent<SpriteRenderer>();
    }
    public void SelectSuit()
    {
        GameManager.GetInstance().currentSuit = unlockSprite;
        suitPreview.sprite = unlockSprite;
        PlayerPrefs.SetString("currentSuit", unlockSprite.name);
    }
}
