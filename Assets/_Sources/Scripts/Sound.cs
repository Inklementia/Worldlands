﻿using UnityEngine;
using UnityEngine.Audio;

namespace _Sources.Scripts
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;

        public bool loop;
        public bool playOnAwake;
        public AudioMixerGroup output;
        [HideInInspector] public AudioSource source;
    }
}