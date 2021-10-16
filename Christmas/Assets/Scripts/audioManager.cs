using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class audioManager : MonoBehaviour
{
    public audio[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(audio a in sounds){
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
        }
    }

    public void Play(string name){
        audio sound = Array.Find(sounds, audio => audio.name == name);
        sound.source.Play();
    }
}
