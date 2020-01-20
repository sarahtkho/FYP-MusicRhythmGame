﻿using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] songs;
    private float startTime;
    private float animationDuration = 2.0f;
    private bool isPlaying = false;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in songs) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }   
    }
    
    void Start() {
        // startTime = Time.time;
        Play("faded");
    }
    void Update() {
        // if ((Time.time - startTime < animationDuration) || isPlaying) {
        //     return;
        // }
        // Play("faded");
        // isPlaying = true;
    }
    public void Play(string name) {
        Sound s = Array.Find(songs, song => song.name == name);
        if (s == null) {
            return;
        }
        s.source.PlayDelayed(2.0f);
    }
}