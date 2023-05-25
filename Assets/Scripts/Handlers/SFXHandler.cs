
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandler : MonoBehaviour
{
    public AudioSource audioSource;

    public void Start()
    {
        SetComponents();
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SetComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
