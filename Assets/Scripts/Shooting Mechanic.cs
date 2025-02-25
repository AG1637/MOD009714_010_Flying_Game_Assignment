using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanic : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate, bulletDamage;
    public bool isAuto;
    public float timer;

    [Header("Initial Setup")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime / fireRate;
        }


        if (isAuto)
        {
            if (Input.GetButton("Fire1") && timer <= 0) //holding left mouse button shoots
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && timer <= 0) //clicking left mouse button shoots
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform); //spawns bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse); //adds force
        bullet.GetComponent<Bullet>().damage = bulletDamage;
        timer = 1;
    }
}
