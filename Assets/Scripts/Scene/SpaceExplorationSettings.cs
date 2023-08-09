using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class SpaceExplorationSettings : MonoBehaviour
{
    public GameObject player;
    public PlayableDirector playableDirector;
    public string nextScene = "GameOver";

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Start()
    {
        SetComponents();

    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        player = GameObject.Find("Player");
        GameManager.GetInstance().GetComponent<HighScoreHandler>().enabled = true;
        GameManager.GetInstance().GetComponent<HighScoreHandler>().highScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();
    }
    public void GameOver()
    {

        playableDirector.Play();
        player.GetComponent<HealthHandler>().enabled = false;
        player.GetComponent<ShieldHandler>().enabled = false;
        player.GetComponent<LocomotionHandler>().enabled = false;
        GameManager.GetInstance().GetComponent<HighScoreHandler>().enabled = false;
    }
    public void SendToGameOverMenu()
    {
        SceneManager.LoadScene(nextScene);
    }

}
