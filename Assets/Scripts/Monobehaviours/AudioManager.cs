﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup group1;
    public AudioMixerGroup group2;
    public AudioMixerGroup group3;
    public AudioMixerGroup group4;
    public SoundComponent[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroyed previous manager");
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (SoundComponent s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixer;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        SoundComponent s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        SoundComponent s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found.");
            return;
        }
        s.source.Stop();
    }

    public void Mute(string name)
    {
        SoundComponent s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found.");
            return;
        }
        s.source.volume = 0.0f;
    }

    public void UnMute(string name)
    {
        SoundComponent s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found.");
            return;
        }
        s.source.volume = 1.0f;
    }

    public bool IsPlaying(string name)
    {
        bool check;
        SoundComponent s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found.");
            return false;
        }
        check = s.source.isPlaying;
        return check;
    }
}

