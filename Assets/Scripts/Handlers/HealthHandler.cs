using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    public PlayerManager playerManager;
    public Slider healthSlider;
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
        // Check if health slider is empty
        if(healthSlider == null)
        {
            // Set health slider to scene object
            healthSlider = GameObject.Find("HealthBarFill").GetComponent<Slider>();
        }
        else
        {
            return;
        }
        
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
        SetHealthBar();

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
    /// When called, this function sets health slider value to current health
    /// </summary>
    public void SetHealthBar()
    {
        healthSlider.value = currentHealth;
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
    }

    public void OnDisable()
    {
        playerManager.isDead = true;

        currentHealth = 0;
    }
}
