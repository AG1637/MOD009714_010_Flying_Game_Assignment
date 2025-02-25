using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int CollectablesRemaining;
    public Collectable[] Collectables;
        
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collectables = FindObjectsOfType<Collectable>();

        CollectablesRemaining = Collectables.Length;
        foreach (Collectable collectable in Collectables)
        {
            Debug.Log(CollectablesRemaining);
        }

        //Show Win Game screen if zero collectables remaining
        if (CollectablesRemaining == 10)
        {
            SceneManager.LoadSceneAsync(2); // win game
        }
    }
}
