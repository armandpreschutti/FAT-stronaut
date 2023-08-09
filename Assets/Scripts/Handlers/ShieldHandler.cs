using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShieldHandler : MonoBehaviour
{


    public GameObject shieldText;
    public GameObject shieldSlider;
    public GameObject spaceExplorationHandler;
    public float currentShield;
    public float maxShield;

    

    public void OnEnable()
    {
        SetComponents();
        SetShieldBar(currentShield);
    }

    public void SetComponents()
    {

        shieldSlider = GameObject.Find("ShieldBar");
        spaceExplorationHandler = GameObject.Find("SpaceExplorationManager");
        currentShield = maxShield;
    }

    public void DamageShield(int damage)
    {
        currentShield -= damage;

        SetShieldBar(currentShield);

        // Check if current health is 0
        if (currentShield <= 0f)
        {

            
            // Return player to ship hub
            spaceExplorationHandler.GetComponent<SpaceExplorationSettings>().GameOver();
        }
    }

    /// <summary>
    /// When called, this function sets health slider value to current health
    /// </summary>
    /// /// <param name="value">desired value of health bar</param>
    public void SetShieldBar(float shieldValue)
    {
        shieldSlider.GetComponent<Slider>().value = shieldValue;
    }


}
