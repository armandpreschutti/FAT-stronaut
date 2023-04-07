using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public LevelManager levelManager;
    public PlayerManager playerManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        levelManager= GetComponent<LevelManager>();
        playerManager= GetComponent<PlayerManager>();

    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Input Connected");
            levelManager.NextScene();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            levelManager.PreviousScene();
        }
    }


}
