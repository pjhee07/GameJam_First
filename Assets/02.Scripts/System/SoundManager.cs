using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : Singleton<SoundManager>
{
    public enum Sound
    {
       Walk = 0,
       Attack,
       Hit,
       Lever,
       Bridge,
       Breaking,
       Dash,
       Door,
       Knock,
       Beep,
       Glass,
       Die,
       End = 12
    }

    AudioSource _audioSource;
    float _sfxVolume = 0.3f;
    private Dictionary<Sound, AudioClip> soundAudioClipDictionary; 

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        soundAudioClipDictionary = new Dictionary<Sound, AudioClip>(); //enum, auidoClip

        foreach (Sound sound in Enum.GetValues(typeof(Sound)))
        {
            soundAudioClipDictionary[sound] = Resources.Load<AudioClip>(sound.ToString()); //하나씩 할당
        }
    }

    public void PlaySFX(Sound sound)
    {
        _audioSource.PlayOneShot(soundAudioClipDictionary[sound], _sfxVolume);
    }
}
