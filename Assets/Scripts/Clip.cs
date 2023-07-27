using System;
using UnityEngine;

[Serializable]
public class Clip 
{
    public AudioClip audio;
    [Range(0,1)]
    public float volume = 0.2f;
}
