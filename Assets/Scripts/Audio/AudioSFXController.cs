using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXController : AudioController
{
    public override void PlayClip(string audioClip, bool isLooping, AudioSource externalAudioSource)
    {
       base.PlayClip(audioClip,isLooping,audioSource);
    }


    public override void PlayOneShot(string audioClip)
    {
        AudioClip audioClip1 = Resources.Load<AudioClip>(audioPath + audioClip);
        audioSource.PlayOneShot(audioClip1, audioManager.SoundEffect);
    }

}
