

using UnityEngine.Audio;
using UnityEngine;
using System;
[System.Serializable]
public class Music
{

    public String name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume;
    
    [HideInInspector]
    public AudioSource source;

    public bool loop;
}
