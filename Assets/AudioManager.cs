using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //PLAYER SOUNDS====================
    [SerializeField]
    private AudioClip footsteps;
    [SerializeField]
    private AudioClip swordSwing;
    [SerializeField]
    private AudioClip jump;
    [SerializeField]
    private AudioClip falling;
    [SerializeField]
    private AudioClip damaged;
    [SerializeField]
    private AudioClip death;

    //ENEMY SOUNDS==============

    //SPIDER//////
    [SerializeField]
    private AudioClip spiderDeath;
    [SerializeField]
    private AudioClip spiderAttack;

    //MOSSGIANT////

    [SerializeField]
    private AudioClip mgDeath;
    [SerializeField]
    private AudioClip mgAttack;
   
    //SKELETON/////
    [SerializeField]
    private AudioClip skDeath;
    [SerializeField]
    private AudioClip skAttack;


    //MUSIC======================

    //MENU
    [SerializeField]
    private AudioClip menuMusic;
    [SerializeField]
    private AudioClip menuButton;

    //GAMEPLAY MUSIC==============
    [SerializeField]
    private AudioClip gameplayMusic;


}
