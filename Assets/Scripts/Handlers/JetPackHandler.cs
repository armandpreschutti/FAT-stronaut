using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackHandler : MonoBehaviour
{
    public PlayerManager playerManager;
    public bool jetActive;

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
        if (jetActive)
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
            // Turn off Jet Pack
            playerManager.jetPackParticleSystem.Stop();
            return;
        }
    }

    /// <summary>
    /// When called, this function activates the players jet
    /// </summary>
    public void SetJetActive()
    {
        jetActive = true;
    }


    /// <summary>
    /// When called, this function deactivates the players jet
    /// </summary>
    public void SetJetInactive()
    {
        jetActive = false;
    }

    public void DestroyAllParticles()
    {
        playerManager.jetPackParticleSystem.Stop(); // Stop the particle system to prevent new particles from being generated
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[playerManager.jetPackParticleSystem.particleCount]; // Create an array to store all particles in the system
        playerManager.jetPackParticleSystem.GetParticles(particles); // Get all particles in the system and store them in the array

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].remainingLifetime = 0; // Set the remaining lifetime of each particle to 0 to destroy them instantly
        }

        playerManager.jetPackParticleSystem.SetParticles(particles, particles.Length); // Set the particles in the system to the modified array to destroy them
    }
}
