using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackHandler : MonoBehaviour
{
    public PlayerManager playerManager;
    
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetJetPackParticleSystem();
    }
    public void SetJetPackParticleSystem()
    {
        // Check to see if there is any player movement input
        if(playerManager.playerInput.moveDirection.magnitude > 0)
        {
            // Turn on Jet Pack
            playerManager.jetPackParticleSystem.Play();
        }
        else
        {
            // Turn off Jet Pack
            playerManager.jetPackParticleSystem.Stop(); 
        }
    }
}
