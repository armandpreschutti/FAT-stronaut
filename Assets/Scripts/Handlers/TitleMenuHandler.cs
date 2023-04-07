using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenuHandler : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    public void Awake()
    {
        
        gameManager = GameManager.GetInstance();

    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void PlayGame()
    {
        gameManager.levelManager.NextScene();
    }
}
