using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class SoundManager: Singleton<SoundManager>
{
    public static GameObject soundGameObject;
    public static GameObject towerSoundEffect;
    public static AudioSource towerSoundAudio;
    public static AudioSource audioSource;
    public static AudioSource bgAudioSource;
    public bool sound;
    public bool music;  

    public enum SoundEffect
    {
        ArrowRelease,
        ArrowImpact,
        IceImpact,
        StoneImpact,
        VictoryEffect,
        GameoverEffect,
    }

    private void Awake()
    {
        if (GetInstance() != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance();
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        bgAudioSource = sources[0];
        audioSource = sources[1];
        sound = true;
        music = true;
    }

    public static void PlaySound(SoundEffect sound)
    {
        if (towerSoundEffect == null)
        {
            towerSoundEffect = new GameObject("TowerSoundEffect");
            towerSoundAudio = towerSoundEffect.AddComponent<AudioSource>();
        }
        if (Instance().gameObject.GetComponent<SoundManager>().enabled)
        {
            if (CanPlaySound(sound))
            {
                towerSoundAudio.PlayOneShot(GetAudioClip(sound));
            }
        }
    }

    private static bool CanPlaySound(SoundEffect sound)
    {
        switch (sound)
        {
            default:
                return true;
            case SoundEffect.IceImpact:
                return true;
        }
    }

    private static AudioClip GetAudioClip(SoundEffect towerSoundEffect)
    {
        foreach(Assets.SoundAudioClip soundAudioClip in Assets.i.soundAudioClips)
        {
            if (soundAudioClip.sound == towerSoundEffect)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + towerSoundEffect + " not found!");
        return null;
    }

    public void ClickButton()
    {
        audioSource.PlayOneShot(Assets.i.buttonClick);
    }

    public void PauseBackGroundMusic()
    {
        bgAudioSource.Pause();
    }

    public void ResumeBackGroundMusic()
    {
        bgAudioSource.UnPause();
    }

    public void MuteBackgroundMusic()
    {
        bgAudioSource.mute = true;
        music = false;
    }

    public void UnMuteBackgroundMusic()
    {
        bgAudioSource.mute = false;
        music = true;
    }

    public void MuteSound()
    {
        audioSource.mute = true;
        sound = false;
    }

    public void UnMuteSound()
    {
        audioSource.mute = false;
        sound = true;
    }
}
