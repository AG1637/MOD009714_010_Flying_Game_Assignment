using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioChatter : MonoBehaviour
{
    public AudioSource radioAudio;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlayChatter", Random.Range(5f,15f), Random.Range(4f,8f));
    }

    void PlayChatter()
    {
        radioAudio.clip = audioClips[Random.Range(0, audioClips.Length)];
        radioAudio.Play();
    }
}
