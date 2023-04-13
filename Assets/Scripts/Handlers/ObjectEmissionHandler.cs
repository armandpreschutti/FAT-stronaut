using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class ObjectEmissionHandler : MonoBehaviour
{
    public float spawnArea;

    public GameObject objectToSpwan;

    public float objectSpeed;

    
    public void Start()
    {
        spawnArea = Random.Range(0f, 10f);
        GameObject spawnObject = Instantiate(objectToSpwan, new Vector3(transform.position.x, Random.Range(1f, 10f), transform.position.z) , transform.rotation);
    }

}
