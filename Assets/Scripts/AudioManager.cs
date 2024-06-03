using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

[Header("------Audio Sources------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    //*-------Add audio sources for music and sfx------*//
[Header("------Audio Clips------")]
public AudioClip mainMenuMusic;
public AudioClip gameMusic1;
public AudioClip gameMusic2;
    public Music currentSong = null;
    void Awake()
    {
        //Ensure singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {

    }


    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void MusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);

    }

    public void SFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}

