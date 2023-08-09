using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{

    public GameObject spaceExplorationSettings;
    public GameObject healthSlider;
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


        // set current health to zero
        currentHealth = 0;
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
        SetHealthBar(currentHealth);

        // Check if current health is 0
        if (currentHealth <= 0f)
        {

            // Return player to ship hub
            spaceExplorationSettings.GetComponent<SpaceExplorationSettings>().GameOver();
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
    /// When called, this function sets health slider value to current health
    /// </summary>
    /// /// <param name="value">desired value of health bar</param>
    public void SetHealthBar(float health)
    {
        healthSlider.GetComponent<Slider>().value = health;
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {

        healthSlider = GameObject.Find("HealthBar");
        spaceExplorationSettings = GameObject.Find("SpaceExplorationSettings");
    }
}
