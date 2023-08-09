using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuSettings : MonoBehaviour
{

    public GameObject settingsMenu;
    public string nextScene = "MainMenu";


    /// <summary>
    /// When called, this function starts game
    /// </summary>
    public void EnterGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    
    public void EnableSettings()
    {
        settingsMenu.SetActive(true);
    }


    public void DisableSettings()
    {
        settingsMenu.SetActive(false);
    }
}
