using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStatesController : AudioController
{
    [SerializeField] private AudioClip[] moveClip;
    [SerializeField] private AudioClip[] jumpClip;
    [SerializeField] private AudioClip[] idleClip;
    [SerializeField] private AudioClip[] hurtClip;
    [SerializeField] private AudioClip[] dieClip;
    [SerializeField] private AudioClip[] attackClip;

    public void PlayStateClip(StateID state, bool isLooping)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.loop = isLooping;
        if (audioManager != null)
        {
            audioSource.volume = audioManager.SoundEffect;
        }
        switch (state)
        {
            case StateID.Move:
                if (moveClip.Length == 0) return;
                audioSource.clip = moveClip[Random.Range(0, moveClip.Length)];
                //audioSource.PlayOneShot(moveClip[Random.Range(0, moveClip.Length)]);
                break;
            case StateID.Jump:
                if (jumpClip.Length == 0) return;
                audioSource.clip = jumpClip[Random.Range(0, jumpClip.Length)];
                //audioSource.PlayOneShot(jumpClip[Random.Range(0, jumpClip.Length)]);
                break;
            case StateID.Idle:
                if (idleClip.Length == 0) return;
                audioSource.clip = idleClip[Random.Range(0, idleClip.Length)];
                //audioSource.PlayOneShot(idleClip[Random.Range(0, idleClip.Length)]);
                break;
            case StateID.Hurt:
                if (hurtClip.Length == 0) return;
                audioSource.clip = hurtClip[Random.Range(0, hurtClip.Length)];
                //audioSource.PlayOneShot(idleClip[Random.Range(0, idleClip.Length)]);
                break;
            case StateID.Die:
                if (dieClip.Length == 0) return;
                audioSource.clip = dieClip[Random.Range(0, dieClip.Length)];
                //audioSource.PlayOneShot(idleClip[Random.Range(0, idleClip.Length)]);
                break;
            case StateID.Attack:
                if (attackClip.Length == 0) return;
                audioSource.clip = attackClip[Random.Range(0, attackClip.Length)];
                break;
            default:
                audioSource.clip = null;
                break;
        }

        if (audioSource.clip is null) return;


        audioSource.Play();

    }

}
