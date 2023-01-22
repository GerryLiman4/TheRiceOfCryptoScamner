using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [field:SerializeField] public float SoundEffect {set;get;} = 0.5f;
    [field:SerializeField] public float BGM {set;get;} = 0.5f;
    
    void Awake()
    {
        AudioManager[] objs = GameObject.FindObjectsOfType<AudioManager>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
