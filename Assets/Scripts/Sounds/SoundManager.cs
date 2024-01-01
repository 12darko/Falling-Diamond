using System.Collections;
using System.Collections.Generic;
using Pattern;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
  
    [SerializeField] private AudioSource audioSource;

    public AudioSource AudioSource
    {
        get => audioSource;
        set => audioSource = value;
    }

    public bool sound;
    
  
    public void SoundOnOff()
    {
        sound = !sound;
    }

    public void PlaySoundFx(AudioClip clip , float volume)
    {
        if (sound)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
