using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// клас для роботи зі звуком

public class SoundController : MonoBehaviour
{
    [SerializeField]public AudioSource soundUI;
    [SerializeField] public AudioSource soundGamePlay;
    [SerializeField] public AudioSource soundGameMusic;
    public AudioClip clickSound;
    public AudioClip goodHitSound;
    public AudioClip badHitSound;
    public AudioClip pushSound;
    
    public void playSoundUI(AudioClip clip)
    {
        soundUI.clip = clip;
        soundUI.Play();
    }

    public void playSoundGameplay(AudioClip clip)
    {
        soundGamePlay.clip = clip;
        soundGamePlay.Play();
    }

    public void playSoundMusic(AudioClip clip)
    {
        soundGameMusic.clip = clip;
        soundGameMusic.Play();
    }

    public void setVolumeEffects(float volume)
    {
        soundUI.volume = volume;
        soundGamePlay.volume = volume;
    }

    public void setVolumeMusic(float volume)
    {
        soundGameMusic.volume = volume;
    }

}
