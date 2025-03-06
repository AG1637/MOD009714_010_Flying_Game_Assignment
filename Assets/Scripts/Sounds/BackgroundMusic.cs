using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) //gives player the ability to mute the music
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }

            else
            {
                audioSource.Play();
            }
        }
    }

}
