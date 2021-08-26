using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assets : MonoBehaviour
{
    // Internal instance reference
    private static Assets _i;

    // Instance reference
    public static Assets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<Assets>("GameAssets"));
            return _i;
        }
    }


    // All references
    public AudioClip buttonClick;
    public AudioClip playBackgroundMusic;

    public SoundAudioClip[] soundAudioClips;
    [System.Serializable]
    public class SoundAudioClip 
    {
        public SoundManager.SoundEffect sound;
        public AudioClip audioClip;
    }

}
