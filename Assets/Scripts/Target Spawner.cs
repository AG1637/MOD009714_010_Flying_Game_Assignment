using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // The collectable prefab to spawn
    public float minRadius = 40f; // Minimum distance from the center
    public float maxRadius = 100f; // Maximum distance from the center
 
    void Start()
    {
        InvokeRepeating("SpawnTarget", Random.Range(5, 10), Random.Range(7, 10));
    }

    void SpawnTarget()
    {
        Vector3 randomPosition = GenerateRandomPosition();
        Instantiate(targetPrefab, randomPosition, Quaternion.identity); 
        Debug.Log("Target Spawned");
    }

    Vector3 GenerateRandomPosition()
    {
        float distance = Random.Range(minRadius, maxRadius);
        float angle = Random.Range(0f, Mathf.PI * 2);
        float height = Random.Range(0, distance);

        // Convert polar coordinates to Cartesian coordinates
        float x = distance * Mathf.Cos(angle);
        float z = distance * Mathf.Sin(angle);
        float y = height - distance / 2;
        // Assuming y = 0 for ground-level placement
        return new Vector3(x, y, z);
    }
}
