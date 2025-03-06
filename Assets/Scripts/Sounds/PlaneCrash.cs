using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCrash : MonoBehaviour
{
    public AudioSource crashAudio;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            crashAudio.Play ();
        }
   
    }
}


