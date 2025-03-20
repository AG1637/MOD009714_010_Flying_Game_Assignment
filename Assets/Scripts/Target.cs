using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private int randomNumber;
    private GameObject text;
    private TextMeshPro collectableText;
    
    private void Start()
    {
        timerCanvas = GameObject.FindGameObjectWithTag("Timer"); //reference to timer script to increase time
        timer = timerCanvas.GetComponent<Timer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>(); //reference to player health script to increase health
        Invoke("DestroyTarget", 10f); //Destroys gameobject after 10 seconds
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Target hit");
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            PlayerBoost();
            Destroy(gameObject);
        }
    }

    private void IncreaseTime()
    {
        float timeAdded = timer.IncreaseTime(10);
        text = Instantiate(timeIncreasedText, transform.position, Quaternion.identity);
        text.transform.LookAt(player.transform);
        collectableText = text.GetComponentInChildren<TextMeshPro>();
        collectableText.text = $"+{(int)timeAdded} Seconds";
    }

    private void IncreaseHealth()
    {
        int healthAdded = 0;
        int healthToAdd = 10;
        playerHealth.health += healthToAdd;
        if (playerHealth.health > playerHealth.maxHealth)
        {
            healthAdded = 0;
            playerHealth.health = playerHealth.maxHealth;
        }
        if (playerHealth.health <= playerHealth.maxHealth - healthToAdd)
        {
            healthAdded = healthToAdd;
        }
        if (playerHealth.health > playerHealth.maxHealth - healthToAdd && playerHealth.health  <= playerHealth.maxHealth)
        {
            healthAdded = playerHealth.maxHealth - playerHealth.health;
        }
        text = Instantiate(healthIncreasedText, transform.position, Quaternion.identity);
        text.transform.LookAt(player.transform);
        collectableText = text.GetComponentInChildren<TextMeshPro>();
        collectableText.text = $"+{healthAdded} Health";
    }

    private void PlayerBoost()
    {
        randomNumber = Random.Range(1, 3); //Generates a random integer 1 or 2
        Debug.Log(randomNumber);
        if (randomNumber == 1) // && playerHealth.health < 95)
        {
            IncreaseHealth();
        }
        if (randomNumber == 2) // && timer.timeRemaining < 110)
        {
            IncreaseTime();
        }
    }

    private void DestroyTarget()
    {
        Destroy(gameObject);
        Debug.Log("Target Destroyed");
    }
}
