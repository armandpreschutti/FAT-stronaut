using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class ObjectEmissionHandler : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public CircleCollider2D spawnArea;
    public int spawnCount;
    public PlayerManager playerManager;
    private bool isLooping = false;
    public float spawnTimeRate;
    public float spawnRateMultiplier;
    public float spawnRateThreshold;
    /// <summary>
    /// On start, this function is called
    /// </summary>
    void Start()
    {
        SetComponents();
        StartLooping();
    }

    public void Update()
    {
        this.transform.position = playerManager.transform.position;
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
        //Vector2 randomPosition = Random.insideUnitCircle * spawnArea.bounds.extents * transform.localScale.x;

        // Create random vector 2 position within top half of collider
        float angle = Random.Range(0f, Mathf.PI *2);

        Vector2 randomPosition = (Vector2)transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnArea.radius;

        // Set a spawn position to random position variable
        Vector3 spawnPosition = new Vector3(randomPosition.x, randomPosition.y, 0f);

        // Create an instance of prefab at spawn position
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        spawnArea = GetComponent<CircleCollider2D>();
        playerManager = PlayerManager.GetInstance();
    }

    private IEnumerator MyCoroutine()
    {
        while (isLooping)
        {
            SpawnPrefab();
            if(spawnTimeRate >= spawnRateThreshold)
            {
                spawnTimeRate = spawnTimeRate * spawnRateMultiplier;
            }
            else
            {
                yield return new WaitForSeconds(spawnTimeRate);
            }
            yield return new WaitForSeconds(spawnTimeRate);
        }
    }

    public void StartLooping()
    {
        if (!isLooping)
        {
            isLooping = true;
            StartCoroutine(MyCoroutine());
        }
    }

    public void StopLooping()
    {
        isLooping = false;
    }
}
