using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackHandler : MonoBehaviour
{
    public PlayerManager playerManager;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    public void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
    }

    /// <summary>
    /// Once every .02 seconds, this function is called
    /// </summary>
    public void FixedUpdate()
    {
        SetJetParticleSystem();
    }

    /// <summary>
    /// When called, this function sets the state of the jet particle system
    /// </summary>
    public void SetJetParticleSystem()
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

    /// <summary>
    /// When called, this function destroys all particles currently running in particle system
    /// </summary>
    public void DestroyAllParticles()
    {
        // Stop system from generating new particles
        playerManager.jetPackParticleSystem.Stop(); // Stop the particle system to prevent new particles from being generated

        // Create an array to store all particles in the system
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[playerManager.jetPackParticleSystem.particleCount];

        // Get all particles in the system and store them in the array
        playerManager.jetPackParticleSystem.GetParticles(particles);

        // Set the remaining lifetime of each particle to 0 to destroy them instantly
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].remainingLifetime = 0; 
        }

        // Set the particles in the system to the modified array to destroy them
        playerManager.jetPackParticleSystem.SetParticles(particles, particles.Length);
    }
}
