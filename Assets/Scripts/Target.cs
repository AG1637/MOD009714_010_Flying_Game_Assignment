using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioSource audioSource;
    private GameObject timerCanvas;
    private Timer timer;
    public GameObject timeIncreasedText;
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject healthIncreasedText;

    private void Start()
    {
        timerCanvas = GameObject.FindGameObjectWithTag("Timer"); //reference to timer scipt to increase time
        timer = timerCanvas.GetComponent<Timer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GetComponent<PlayerHealth>(); //reference to timer scipt to increase health
        Invoke("DestroyTarget", 10f); //Destroys gameobject after 10 seconds
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Target hit");
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            IncreaseTime();
            IncreaseHealth();
            Destroy(gameObject);
        }
    }

    private void IncreaseTime()
    {
        timer.IncreaseTime(10);
        Instantiate(timeIncreasedText, transform.position, Quaternion.identity);
    }

    private void IncreaseHealth()
    {
        playerHealth.health += 10;
        Instantiate(healthIncreasedText, transform.position, Quaternion.identity);
    }
    private void DestroyTarget()
    {
        Destroy(gameObject);
        Debug.Log("Target Destroyed");
    }
}
