using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip coin;
    public AudioClip button;
    public AudioClip explodir;
    public static SoundController current;
    private AudioSource audioSource;
    void Start()
    {
        current = this;
        audioSource = GetComponent<AudioSource>();
    }
public void PlayMusic(AudioClip clip){
    audioSource.PlayOneShot(clip);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
