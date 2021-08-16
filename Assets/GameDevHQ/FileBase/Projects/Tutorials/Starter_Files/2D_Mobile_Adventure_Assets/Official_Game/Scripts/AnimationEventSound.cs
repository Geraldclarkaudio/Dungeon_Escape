using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AnimationEventSound : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioClip[] swordSwing;

    private AudioSource fsAudioSource;
    [SerializeField]
    private AudioMixerGroup fsAudioMixerGroup;

    private AudioSource attackAudioSource;
    [SerializeField]
    private AudioMixerGroup attackAudioGroup;

    private Player player;

    private void Start()
    {
        
        fsAudioSource = gameObject.AddComponent<AudioSource>();
        fsAudioSource.outputAudioMixerGroup = fsAudioMixerGroup;

        attackAudioSource = gameObject.AddComponent<AudioSource>();
        attackAudioSource.outputAudioMixerGroup = attackAudioGroup;

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
            
            fsAudioSource.clip = footsteps[Random.Range(0, 4)];
            fsAudioSource.pitch = Random.Range(0.9f, 1.2f);
            fsAudioSource.Play();
        }
    }

    public void AttackSound()
    {
        attackAudioSource.clip = swordSwing[Random.Range(0, 4)];
        attackAudioSource.pitch = Random.Range(0.9f, 1.2f);
        attackAudioSource.Play();
    }
}
