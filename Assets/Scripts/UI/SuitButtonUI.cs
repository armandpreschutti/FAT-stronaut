using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuitButtonUI : MonoBehaviour
{
    public SpriteRenderer suitPreview;
    public Sprite unlockSprite;
    public Sprite lockSprite;
    public bool isUnlocked;

    void Start()
    {
        suitPreview = GameObject.Find("Preview").GetComponent<SpriteRenderer>();
        if(PlayerPrefs.GetString(unlockSprite.name) == "unlocked")
        {
            GetComponent<Image>().sprite = unlockSprite;
            isUnlocked= true;
        }
        else
        {
            GetComponent<Image>().sprite = lockSprite;
            isUnlocked= false;
        }
    }
    public void SelectSuit()
    {
        if (isUnlocked)
        {
            GameManager.GetInstance().currentSuit = unlockSprite;
            suitPreview.sprite = unlockSprite;
            PlayerPrefs.SetString("currentSuit", unlockSprite.name);
        }
        else
        {
            return;
        }

    }
    
}
