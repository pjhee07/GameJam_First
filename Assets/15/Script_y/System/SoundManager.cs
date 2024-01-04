using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : Singleton<SoundManager>
{
    public enum Sound
    {
       Walk,
       Attack,
       Hit,
       Door,
       Leber,
       Brigde,
       Breaking,
       Dash
    }

    AudioSource audioSource;
    private Dictionary<Sound, AudioClip> soundAudioClipDictionary; //타입

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundAudioClipDictionary = new Dictionary<Sound, AudioClip>(); //enum, auidoClip

        foreach (Sound sound in Enum.GetValues(typeof(Sound))) //Sound sound 객체에 enum Value의 01234값 가져옴
        {
            soundAudioClipDictionary[sound] = Resources.Load<AudioClip>(sound.ToString()); //하나씩 할당
        }
    }

    public void PlaySound(Sound sound)
    {
        audioSource.PlayOneShot(soundAudioClipDictionary[sound]); //
    }
}
