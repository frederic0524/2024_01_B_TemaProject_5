using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // ��ȯ�� �������� ������
    public GameObject itemPrefab;

    // ��ȯ�� �������� ��
    public int itemCount = 10;

    // ��ȯ ����
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
            // ���� ��ġ ����
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            // ������ ��ȯ
            Instantiate(itemPrefab, randomPosition, Quaternion.identity);
        }
    }
}
