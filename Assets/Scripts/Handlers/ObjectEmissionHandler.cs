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
    //private bool isLooping = false;
    public float spawnTimeRate;
   // public float spawnRateMultiplier;
    public float spawnRateThreshold;

    /// <summary>
    /// On start, this function is called
    /// </summary>
    void OnEnable()
    {
        SetComponents();
        StartCoroutine(RepeatSpawning());
    }

    public void Update()
    {
        this.transform.position = new Vector3(20, player.transform.position.y,0);
    }
   
    /// <summary>
    /// When called, this coroutine spawns a object then waits a certain amount of time before respawning again.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RepeatSpawning()
    {
        
        /* if(spawnTimeRate >= spawnRateThreshold)
         {
             spawnTimeRate = spawnTimeRate * spawnRateMultiplier;
         }
         else
         {
             yield return new WaitForSeconds(spawnTimeRate);
         }*/
        yield return new WaitForSeconds(spawnTimeRate);
        SpawnPrefab();
        StartCoroutine(RepeatSpawning());
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

    /*
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
        }*/
}
