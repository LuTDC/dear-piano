﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class music
{

    public string name;
    public AudioClip clip;
    public float volume = 1f;

    [HideInInspector]
    public AudioSource source;
}
