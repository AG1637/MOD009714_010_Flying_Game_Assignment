using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public TextMeshProUGUI healthText;
    public HealthBar healthBar;

    // Update is called once per frame

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        healthBar.SetHealth(health);
        playerHealth();
    }

    private void playerHealth()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(4);
        }
        //healthText.text = health.ToString();
    }
}
