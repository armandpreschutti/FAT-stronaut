using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using Unity.VisualScripting;

using DG.Tweening.Core.Easing;

public class ObjectEmissionHandler : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public BoxCollider2D spawnArea;
    public int spawnCount;
    public PlayerManager playerManager;
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
        // Set spawn position to random point
        //Vector3 spawnPosition = GetRandomSide();

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
        playerManager = PlayerManager.GetInstance();
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


    /*/// <summary>
    /// When called, this function returns a Vector 3 of a random point along the perimeter of box collider
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRandomSide()
    {
        // Choose a random side of the box collider
        int side = Random.Range(0, 4);

        // Choose a random point on the chosen side of the box collider
        float x, y;
        switch (side)
        {
            case 0: // Top side
                x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                y = spawnArea.bounds.max.y;
                break;
            case 1: // Right side
                x = spawnArea.bounds.max.x;
                y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                break;
            case 2: // Bottom side
                x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                y = spawnArea.bounds.min.y;
                break;
            default: // Left side
                x = spawnArea.bounds.min.x;
                y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                break;
        }

        // Return the chosen random point on the outside of the box collider
        return new Vector3(x, y, 0);
    }*/

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the object is player
        if (collision.tag == "Object")
        {
            // Deactivate enter button
            Destroy(collision);
        }

        else
        {
            return;
        }
    }*/
}
