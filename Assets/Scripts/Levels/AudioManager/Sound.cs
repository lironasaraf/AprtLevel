using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] private string name;
    [Range(0f, 1f)]
    [SerializeField] private float volume;
    [Range(0f, 1f)]
    [SerializeField] private float pitch;
    [SerializeField] private bool loop;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;

    public AudioSource getAudioSource()
    {
        return source;
    }

    public void setAudioSource(AudioSource source)
    {
        this.source = source;
    }

    public string getName()
    {
        return name;
    }

    public float getPitch()
    {
        return pitch;
    }

    public bool getLoop()
    {
        return loop;
    }

    public AudioClip getAudioClip()
    {
        return clip;
    }

    public float getVolume()
    {
        return volume;
    }
}
