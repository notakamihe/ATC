using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiperAudio : MonoBehaviour
{
    public float playDelay = 1;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad % playDelay > playDelay - .1)
        {
            audioSource.PlayOneShot(audioSource.clip, .1f);
        }
    }
}
