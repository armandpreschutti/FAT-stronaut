using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class ObjectEmissionHandler : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Collider2D spawnArea;
    public int spawnCount;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    void Start()
    {
        StartSpawn();
    }

    /// <summary>
    /// When called, this function executes a spawn prefab function repeatedly, with number 
    /// of repetitions being equal to value of the spawn count variable
    /// </summary>
    public void StartSpawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnPrefab();
        }
    }

    /// <summary>
    /// When called, this function spawns a prefab at a random location within collider bounds
    /// </summary>
    void SpawnPrefab()
    {
        // Create random vector 2 position within collider
        Vector2 randomPosition = Random.insideUnitCircle * spawnArea.bounds.extents * transform.localScale.x;

        // Set a spawn position to random position variable
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0f);

        // Create an instance of prefab at spawn position
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        spawnArea = GetComponent<Collider2D>();
    }
}
