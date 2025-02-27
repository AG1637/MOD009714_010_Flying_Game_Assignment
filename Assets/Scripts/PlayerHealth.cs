using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float health = 100;
    [SerializeField] TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //temp damage system
        if (Input.GetKeyDown(KeyCode.M))
        {
            health -= 10;
        }
        playerHealth();
    }

    private void playerHealth()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(4);
        }
        healthText.text = health.ToString();
    }
}
