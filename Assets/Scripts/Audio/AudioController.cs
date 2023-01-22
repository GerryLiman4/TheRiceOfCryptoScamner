using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] protected readonly string audioPath = "Sounds/";
    protected AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    public virtual void PlayClip(string audioClip, bool isLooping, AudioSource externalAudioSource)
    {
        if (audioSource.isPlaying)
        {
            externalAudioSource.Stop();
        }
        externalAudioSource.loop = isLooping;
        externalAudioSource.clip = Resources.Load<AudioClip>(audioPath + audioClip);
    
        if (audioManager != null)
        {
            externalAudioSource.volume = audioManager.SoundEffect;
        }

        externalAudioSource.Play();
    }

    public virtual void StopClip()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.loop = false;
        }
    }

    public virtual void PlayOneShot(string audioClip)
    {
        AudioClip audioClip1 = Resources.Load<AudioClip>(audioPath + audioClip);
        audioSource.PlayOneShot(audioClip1, audioManager.SoundEffect);
    }
}
