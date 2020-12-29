using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake ()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.enabled = s.enabled;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
            s.source.time = s.time;
        }
    }

    void Start()
    {
        Play("GameMusic");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "cannot be found.");
            return;
        }

        if (s.source.enabled) { s.source.Play(); }
        
    }

    public void PlayOneShot (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "cannot be found.");
            return;
        }

        if (s.source.enabled) { s.source.PlayOneShot(s.source.clip, .4f); }
    }

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "cannot be found.");
            return;
        }

        if (s.source.enabled) { s.source.Stop(); }
    }
}
