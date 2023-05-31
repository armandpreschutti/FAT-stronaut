using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShieldHandler : MonoBehaviour
{

    public PlayerManager playerManager;
    public GameObject ShieldSlider;
    public float currentShield;
    public float maxHealth;
    public float regenerationRate;

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
        currentShield = 0;
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
        // Set death state to false
        playerManager.isDead = false;

        // Set current health to max health 
        currentShield = maxHealth;
    }

    /// <summary>
    /// When called, this function depletes player health
    /// </summary>
    public void DepleteHealth()
    {
        // Reduce current health by depletion rate multiplied by time since last frame
        currentShield -= regenerationRate * Time.deltaTime;

        // Clamp current health between 0 and starting health
        currentShield = Mathf.Clamp(currentShield, 0f, maxHealth);

        // Set health bar value
        SetHealthBar(currentShield);

        // Check if current health is 0
        if (currentShield == 0f)
        {
            // Set death state to true
            playerManager.isDead = true;

            // Return player to ship hub
            SceneManager.LoadScene("GameOver");
        }
    } 
    /// <summary>
    /// When called, this function adds a certain value to current health
    /// </summary>
    /// <param name="health">amount to add to current health</param>
    public void ChangeHealth(float health)
    {
        // add helath value to current health
        currentShield += health;
    }

    /// <summary>
    /// When called, this function sets health slider value to current health
    /// </summary>
    /// /// <param name="value">desired value of health bar</param>
    public void SetHealthBar(float health)
    {
        ShieldSlider.GetComponent<Slider>().value = health;
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        playerManager = GetComponent<PlayerManager>();
        ShieldSlider = GameObject.Find("HealthBar");
    }
    /*public PlayerManager playerManager;
    public UIManager uiManager;
    public GameObject shieldText;
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
        uiManager = UIManager.GetInstance();
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
    /// <summary>
    /// When called, this function depletes player health
    /// </summary>
    public void DepleteHealth()
    {
        // Reduce current health by depletion rate multiplied by time since last frame
        currentShield += regenerationRate * Time.deltaTime;

        // Clamp current health between 0 and starting health
        currentHealth = Mathf.Clamp(currentHealth, 0f, MaxHealth);

        // Set health bar value
        SetHealthBar(currentHealth);

        // Check if current health is 0
        if (currentHealth == 0f)
        {
            // Set death state to true
            playerManager.isDead = true;

            // Return player to ship hub
            SceneManager.LoadScene("GameOver");
        }
    }*/

}
