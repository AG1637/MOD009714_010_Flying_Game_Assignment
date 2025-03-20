using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining;

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 11)
            {
                timerText.color = Color.red;
            }
        }
        else if (timeRemaining < 0)
        {
            timeRemaining = 0;
            SceneManager.LoadScene(3); // lose game
        }
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float IncreaseTime(float TimeToAdd)
    {
        float timeAdded = 0;
        timeAdded = 120 - timeRemaining;
        if (timeAdded > TimeToAdd)
        {
            timeAdded = TimeToAdd;
        }
        if (timeRemaining < 120)
        {
            timeRemaining += TimeToAdd;
        }
        if (timeRemaining >= 110 && timeRemaining <= 120)
        {
            timeRemaining = 120;
        }
        if (timeRemaining >= 120)
        {
            timeRemaining = 120;
        }
        return timeAdded;   
    }
}
