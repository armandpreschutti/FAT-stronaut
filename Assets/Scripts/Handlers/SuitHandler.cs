using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SuitHandler : MonoBehaviour
{
    public GameManager gameManager;
    public SpriteRenderer playerRenderer;
    public Sprite[] suits;
    public Sprite currentSuit;
    public int suitIndex;
    public bool suitChange;

    public void Start()
    {
        gameManager = GameManager.GetInstance();
        playerRenderer= PlayerManager.GetInstance().GetComponent<SpriteRenderer>();
        suitIndex = 0;
    }

    public void Update()
    {
        if(suitChange)
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                NextSuit();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                PreviousSuit();
            }
        }
        else
        {
            return;
        }
    }

    public void NextSuit()
    {
        if(suitIndex < suits.Length -1)
        {
            suitIndex++;
            playerRenderer.sprite = suits[suitIndex];
        }
        else
        {
            return;
        }
        
    }
    public void PreviousSuit()
    {
        if (suitIndex > 0)
        {
            suitIndex--;
            playerRenderer.sprite = suits[suitIndex];
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            suitChange= true;
            
        }
        else
        {
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            suitChange = false;

        }
        else
        {
            return;
        }
    }
}
