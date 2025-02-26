using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 5;
    public float lifeTime = 3;
    // Start is called before the first frame update
    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterMovement>() != null)
        {
            other.GetComponent<CharacterMovement>().health -= damage;
            Destroy(gameObject);
        }
    }
}
