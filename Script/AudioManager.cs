using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip musicClip;
    public AudioClip soundClip;
    public AudioSource audioSound;
    public AudioSource audioMusic;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        audioMusic = GetComponent<AudioSource>();
        audioSound = GetComponent<AudioSource>();
        audioMusic.clip = musicClip;
        audioMusic.Play();
    }

    public void PlayClickSound()
    {
        audioSound.PlayOneShot(soundClip);
    }
}
