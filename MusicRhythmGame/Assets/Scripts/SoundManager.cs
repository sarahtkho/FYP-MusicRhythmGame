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
        startTime = Time.time;
        Sound s = Array.Find(songs, song => song.name == "faded");
        Debug.Log("Volume: " + s.volume);
        Debug.Log("Pitch: "+ s.pitch);
        Debug.Log("Length: "+ s.clip.length);
        Play("faded");
    }
    void Update() {}
    public void Play(string name) {
        Sound s = Array.Find(songs, song => song.name == name);
        if (s == null) {
            return;
        }
        s.source.PlayDelayed(animationDuration);
    }

    public bool IsMusicEnding() {
        Sound s = Array.Find(songs, song => song.name == "faded");
        if (s == null || s.source == null) {
            return false;
        }
        float remainingTime = s.clip.length - (Time.time - startTime); 
        if (remainingTime < 35.0f) {
            return true;
        }
        return false;
    }
}
