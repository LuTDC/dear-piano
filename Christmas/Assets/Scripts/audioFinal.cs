using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class audioFinal : MonoBehaviour
{
    public music[] msc;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(music m in msc){
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
        }
    }

    public music Play(string name){
        music sound = Array.Find(msc, music => music.name == name);
        sound.source.Play();

        return sound;
    }
}
