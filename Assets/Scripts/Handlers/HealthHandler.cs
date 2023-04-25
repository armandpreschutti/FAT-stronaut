using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthHandler : MonoBehaviour
{
    public PlayerManager playerManager;
    public UIManager uiManager;
    public float currentHealth;
    public float MaxHealth;
    public float depletionRate;

    /// <summary>
    /// This function is called when script is enabled
    /// </summary>
    public void OnEnable()
    {
        SetComponents();
        ResetHealth();
    }

    /// <summary>
    /// On Disable, this function will be called
    /// </summary>
    public void OnDisable()
    {
        // Set player state to dead
        playerManager.isDead = true;

        // set current health to zero
        currentHealth = 0;

        // Set health bar to inactive
        uiManager.ActivateHealthBar(false);
    }


    /// <summary>
    /// This function is called once every frame
    /// </summary>
    public void Update()
    {
        DepleteHealth();
    }


    /// <summary>
    /// When called, this function resets player health variabls
    /// </summary>
    public void ResetHealth()    
    {
        uiManager.ActivateHealthBar(true);
        
        // Set death state to false
        playerManager.isDead =false;

        // Set current health to max health 
        currentHealth = MaxHealth;
    }

    /// <summary>
    /// When called, this function depletes player health
    /// </summary>
    public void DepleteHealth()
    {
        // Reduce current health by depletion rate multiplied by time since last frame
        currentHealth -= depletionRate * Time.deltaTime;

        // Clamp current health between 0 and starting health
        currentHealth = Mathf.Clamp(currentHealth, 0f, MaxHealth); 
        
        // Set health bar value
        uiManager.SetHealthBar(currentHealth);

        // Check if current health is 0
        if (currentHealth == 0f)
        {
            // Set death state to true
            playerManager.isDead = true;

            // Return player to ship hub
            playerManager.gameManager.levelManager.SwitchScene(2);
        }
    }

    /// <summary>
    /// When called, this function adds a certain value to current health
    /// </summary>
    /// <param name="health">amount to add to current health</param>
    public void ChangeHealth(float health)
    {
        // add helath value to current health
        currentHealth += health;
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        playerManager = GetComponent<PlayerManager>();
        uiManager = UIManager.GetInstance();
    }
}
