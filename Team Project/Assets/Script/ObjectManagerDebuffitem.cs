using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManagerDebuffitem : MonoBehaviour
{
    public GameObject objectPrefab;
    public int initialObjectCount = 2;
    public int maxObjects = 2;
    public int minObjects = 0;
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    private int currentObjectCount;

    void Start()
    {
        for (int i = 0; i < initialObjectCount; i++)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        Instantiate(objectPrefab, randomPosition, Quaternion.identity);
        currentObjectCount++;
    }

    public void ObjectCollected()
    {
        currentObjectCount--;

        if (currentObjectCount <= minObjects)
        {
            int objectsToSpawn = maxObjects - currentObjectCount;
            for (int i = 0; i < objectsToSpawn; i++)
            {
                SpawnObject();
            }
        }
    }
}
