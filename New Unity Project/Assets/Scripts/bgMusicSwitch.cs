using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusicSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public AudioClip[] audios;
    void Start()
    {
        source.Play();        
    }

    // Update is called once per frame
    public void changeAudio(int value)
    {
        source.clip = audios[value];
        source.Play();
    }
}
