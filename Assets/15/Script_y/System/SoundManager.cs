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
    private Dictionary<Sound, AudioClip> soundAudioClipDictionary; //Ÿ��

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundAudioClipDictionary = new Dictionary<Sound, AudioClip>(); //enum, auidoClip

        foreach (Sound sound in Enum.GetValues(typeof(Sound))) //Sound sound ��ü�� enum Value�� 01234�� ������
        {
            soundAudioClipDictionary[sound] = Resources.Load<AudioClip>(sound.ToString()); //�ϳ��� �Ҵ�
        }
    }

    public void PlaySound(Sound sound)
    {
        audioSource.PlayOneShot(soundAudioClipDictionary[sound]); //
    }
}
