using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    private Rigidbody rb;
    public float damage;
    public float lifeTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speed, 0, 0);
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy_AI>() != null)
            other.GetComponent<Enemy_AI>().health -= damage;

        Destroy(gameObject);
    }
}
