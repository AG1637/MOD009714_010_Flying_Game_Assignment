using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed = 150;
    public float fireRate = 0.2f;
    private float timer;

    [Header("Initial Setup")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime / fireRate;
        }
       
        if (Input.GetButton("Fire1") && timer <= 0) //pressing left mouse button shoots
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0) //pressing spacebar shoots
        {
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform); //spawns bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse); //adds force
        timer = 1;
    }
}
