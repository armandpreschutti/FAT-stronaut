using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using Unity.VisualScripting;

using DG.Tweening.Core.Easing;

public class ObjectEmissionHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject prefabToSpawn;
    public BoxCollider2D spawnArea;
    public int spawnCount;
    private bool isLooping = false;
    public float spawnTimeRate;
    public float spawnRateMultiplier;
    public float spawnRateThreshold;
    public float startDelayTime;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    void Start()
    {
        SetComponents();
        Invoke("StartLooping", startDelayTime);
    }

    public void Update()
    {
        this.transform.position = player.transform.position;
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
        Bounds bounds = spawnArea.bounds;

        Vector3 spawnPosition = new Vector3(bounds.center.x, Random.Range(bounds.min.y, bounds.max.y), 0f);

        // Create an instance of prefab at spawn position
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

    }

    /// <summary>
    /// When called, this function sets all components needed
    /// </summary>
    public void SetComponents()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
    }

    /// <summary>
    /// When called, this coroutine spawns a object then waits a certain amount of time before respawning again.
    /// </summary>
    /// <returns></returns>
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
