using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [Header("Patrolling")]
    public Transform pointA;
    public Transform pointB;
    public float speed = 15f;
    private Vector3 currentTarget;

    [Header("Chase player")]
    public Transform player;
    public float followRange = 1000f;
    public float chaseSpeed = 20f;

    [Header("AttackPlayer")]
    public float attackRange = 100f;
    public float timer = 0;
    public float attackCooldown = 1f;
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100;
    [Header("Health")]
    public float Enemyhealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        //ChasePlayer();
        Patrol();
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            AttackCooldown();
        }
        if (Enemyhealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ChasePlayer()
    {
        float distancetoplayer = Vector3.Distance(transform.position, player.position);

        if (distancetoplayer <= followRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        }
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentTarget) < 0.1)
        {
            if ((currentTarget == pointA.position))
            {
                currentTarget = pointB.position;
            }
            else
            {
                currentTarget = pointA.position;
            }
        }
    }

    private void AttackCooldown()
    {
        if (timer < attackCooldown)
        {
            timer += Time.deltaTime;
        }
        else
        {
            AttackPlayer();
            timer = 0;
        }
    }

    private void AttackPlayer()
    {
        Debug.Log("Attacking player");
        transform.LookAt(player);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (player.position - bulletSpawnTransform.position).normalized;
            rb.AddForce(direction * bulletSpeed, ForceMode.Impulse);
        }
    }
}
