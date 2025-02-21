﻿using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;


public class audio_manager : MonoBehaviour
{

    public Sound[] sounds;
    private String[] dinosaurHappyNoises = {"happyDinosaurNoise1", "happyDinosaurNoise2", "happyDinosaurNoise3" };

    public static audio_manager instance;


    // Start is called before the first frame update
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void play_random_happy_sound()
    {
        Play(dinosaurHappyNoises[UnityEngine.Random.Range(0,dinosaurHappyNoises.Length)]);
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
