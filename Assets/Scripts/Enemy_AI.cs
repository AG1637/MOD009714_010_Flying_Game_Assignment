using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    //Patrol between two points
    public Transform pointA;
    public Transform pointB;
    public float speed = 15f;
    private Vector3 currentTarget;
    //Chase player
    public Transform player;
    public float followRange = 1000f;
    public float chaseSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        Patrol();
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
}
