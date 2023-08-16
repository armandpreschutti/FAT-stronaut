using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class SuitHandler : MonoBehaviour
{
    
    public List<Sprite> suits;
    public List<Sprite> lockedSuits;
    public List<Sprite> unlockedSuits;


   /* public void Update()
    {
        *//*///////////DEBUG CONTROLS/////////////////
        if (Input.GetButtonDown("Fire2"))
        {
            ClearAllSuits();
        }*//*
    }*/
    public void Start()
    {
        CheckSuitSaveData();
    }
    public void CheckSuitStatus()
    {
        foreach (Sprite suit in suits)
        {
            if (PlayerPrefs.GetString(suit.name) == "unlocked")
            {
                unlockedSuits.Add(suit);
            }
            else
            {
                lockedSuits.Add(suit);
            }
        }
    }

    public void ClearAllSuits()
    {
        PlayerPrefs.DeleteAll();
    }

    public void CheckSuitSaveData()
    {
        foreach (Sprite suit in suits)
        {
            if (!PlayerPrefs.HasKey(suit.name))
            {
                PlayerPrefs.SetString(suit.name, "locked");
            }            
        }

        CheckSuitStatus();
    }

    public void UnlockSuit(Sprite suit)
    {
        if(PlayerPrefs.GetString(suit.name) == "locked")
        {
            PlayerPrefs.SetString(suit.name, "unlocked");
            unlockedSuits.Add(suit);
            lockedSuits.Remove(suit);
        }
        else
        {
            return;
        }
    }
}
