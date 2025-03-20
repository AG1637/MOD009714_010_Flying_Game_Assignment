using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 5;
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
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerHealth>() != null)
            {
                other.GetComponent<PlayerHealth>().health -= damage;
                Destroy(gameObject);
            }
        }
    }
}
