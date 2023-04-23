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
    /// This function is called when script is created
    /// </summary>
    public void Awake()
    {
        SetComponents();
    }

    /// <summary>
    /// This function is called when script is enabled
    /// </summary>
    public void OnEnable()
    {
        ResetHealth();
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

    

    public void ChangeHealth(float health)
    {
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

    public void OnDisable()
    {
        playerManager.isDead = true;

        currentHealth = 0;

        uiManager.ActivateHealthBar(false);
    }
}
