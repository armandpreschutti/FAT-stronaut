using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackHandler : MonoBehaviour
{
    public PlayerManager playerManager;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    void Start()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }

    /// <summary>
    /// Once every .02 seconds, this function is called
    /// </summary>
    void FixedUpdate()
    {
        SetJetParticleSystem();
    }

    /// <summary>
    /// When called, this function sets the state of the jet particle system
    /// </summary>
    public void SetJetParticleSystem()
    {
        // Check if the the jet is active
        if (playerManager.jetActive)
        {
            // Check if there is any player movement input
            if (playerManager.playerInput.moveDirection.magnitude > 0)
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
        else
        {
            return;
        }
       
    }
}
