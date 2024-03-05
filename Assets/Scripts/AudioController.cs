using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] musics;
    public AudioSource audioSource;
    private int i = 0;
    public void NextMusic()
    {
        audioSource.clip = musics[i];
        i++;
        if(i == musics.Length - 1) i = 0;
        audioSource.Play();
    }
}
