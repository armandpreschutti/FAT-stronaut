using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShieldHandler : MonoBehaviour
{

    PlayerManager playerManager;
    public GameObject shieldText;
    public GameObject[] shieldBars;
    public float currentShield;
    public float maxShield;

    

    public void OnEnable()
    {
        SetComponents();
        SetShieldText();
    }

    public void SetComponents()
    {
        playerManager = GetComponent<PlayerManager>();

        shieldText = GameObject.Find("ShieldText");
        currentShield = maxShield;
    }

    public void DamageShield(int damage)
    {
        currentShield -= damage;
        SetShieldText();
    }

    public void SetShieldText()
    {
        shieldText.GetComponent<Text>().text = currentShield.ToString();
    }
    

}
