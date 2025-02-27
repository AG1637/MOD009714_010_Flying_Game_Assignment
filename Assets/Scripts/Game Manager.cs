using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int collectablesRemaining;
    [SerializeField] TextMeshProUGUI collectablesRemainingNumber; 
    public Collectable[] Collectables;
        
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        collectablesRemainingNumber.text = collectablesRemaining.ToString();
        Collectables = FindObjectsOfType<Collectable>();

        collectablesRemaining = Collectables.Length;
        //Show Win Game screen if zero collectables remaining
        if (collectablesRemaining == 0)
        {
            SceneManager.LoadSceneAsync(2); // win game
        }
    }
}
