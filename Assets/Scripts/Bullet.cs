using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10;
    public float lifeTime = 3;
    // Start is called before the first frame update
    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy (gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy_AI>() != null)
        {
            other.GetComponent<Enemy_AI>().Enemyhealth -= damage;
            Destroy(gameObject);
        }
    }
}
