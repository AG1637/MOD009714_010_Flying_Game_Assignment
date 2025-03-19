using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyText", 3f);
    }

    private void DestroyText()
    {
        Destroy(gameObject);
    }
}

