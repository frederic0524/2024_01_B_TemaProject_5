using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManagerSword : MonoBehaviour
{
    public GameObject objectPrefab;
    public int initialObjectCount = 10;
    public int maxObjects = 10;
    public int minObjects = 4;
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    private int currentObjectCount;

    private int[] swordRank =new int[12];            //�� �ܰ躰 ���� ������ ������ �迭

    void Start()
    {
        for (int i = 0; i < initialObjectCount; i++)
        {
            SpawnObject();
        }

        for (int i = 0; i < 12; i++)
        {
            swordRank[i] = 0;                           //�迭 �ʱ�ȭ
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

    public void ObjectCollected(int rank)           //���� �ܰ踦 �޾ƿ� �Ű����� �߰�
    {
        swordRank[rank - 1]++;                      //���� �� �ܰ迡 �ش��ϴ� �迭�� ���� 1 �߰�                     
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

     void Update()                              //���� �� ���� �ִ��� �Ǵ�
    {
        for(int i = 0; i <12; i++)              //�ܰ躰 �� ���� �ľ�
        {
            if(swordRank[i] >= 2 && i <12)      //Ư�� �ܰ��� �� ������ 2���� �Ѿ�ٸ�
            {
                swordRank[i] -=2;               //�� �ܰ��� �� ���� -2
                swordRank[i + 1]++;             //���� �ܰ��� �� ���� 1�� �߰�
            }
        }
    }
}