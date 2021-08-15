using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventSound : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] footsteps;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void FootStepAudio()
    {
        _audioSource.clip = footsteps[Random.Range(0, 4)];
        _audioSource.pitch = Random.Range(0.9f, 1.2f);
        _audioSource.Play();
    }
}
