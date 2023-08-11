using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using DG.Tweening.Core.Easing;

public class ObjectEmissionHandler : MonoBehaviour
{
    
    public BoxCollider2D spawnArea;

    public GameObject prefabToSpawn;
    public float spawnRate;


    /// <summary>
    /// On start, this function is called
    /// </summary>
    void OnEnable()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        StartCoroutine(RepeatSpawning());
    }

    /// <summary>
    /// When called, this coroutine spawns a object then waits a certain amount of time before respawning again.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RepeatSpawning()
    {
        yield return new WaitForSeconds(spawnRate);
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

}
