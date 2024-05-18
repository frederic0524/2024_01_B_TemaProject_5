using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // 소환할 아이템의 프리팹
    public GameObject itemPrefab;

    // 소환할 아이템의 수
    public int itemCount = 10;

    // 소환 범위
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        for (int i = 0; i < itemCount; i++)
        {
            // 랜덤 위치 생성
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            // 아이템 소환
            Instantiate(itemPrefab, randomPosition, Quaternion.identity);
        }
    }
}
