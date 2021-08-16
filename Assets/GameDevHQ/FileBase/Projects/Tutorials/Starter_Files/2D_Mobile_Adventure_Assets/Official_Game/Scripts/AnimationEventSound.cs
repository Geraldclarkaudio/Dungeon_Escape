using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventSound : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] footsteps;
    public AudioClip[] swordSwing;

    private Player player;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if(_audioSource == null)
        {
            Debug.LogError("AudioSource is Null");

        }
        player = GetComponentInParent<Player>();

        if (player == null)
        {
            Debug.LogError("Player is Null");

        }
    }

    public void FootStepAudio()
    {
        if(player.Grounded() == true)
        {
            _audioSource.clip = footsteps[Random.Range(0, 4)];
            _audioSource.pitch = Random.Range(0.9f, 1.2f);
            _audioSource.Play();
        }
    }

    public void AttackSound()
    {
        _audioSource.clip = swordSwing[Random.Range(0, 4)];
        _audioSource.pitch = Random.Range(0.9f, 1.2f);
        _audioSource.Play();
    }
}
