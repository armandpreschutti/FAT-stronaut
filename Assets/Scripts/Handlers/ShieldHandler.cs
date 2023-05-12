using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHandler : MonoBehaviour
{
    public PlayerManager playerManager;
    public UIManager uiManager;
    public int currentShield;
    public int maxShield;

    public void OnEnable()
    {
        SetComponents();
    }

    public void SetComponents()
    {
        playerManager = GetComponent<PlayerManager>();
        uiManager = UIManager.GetInstance();
    }
    public void ChangeShield(int damage)
    {
        currentShield -= damage;
    }
}
