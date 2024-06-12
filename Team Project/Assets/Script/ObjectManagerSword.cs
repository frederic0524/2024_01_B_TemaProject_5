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

    private int[] swordRank =new int[12];            //각 단계별 검의 갯수를 저장할 배열

    void Start()
    {
        for (int i = 0; i < initialObjectCount; i++)
        {
            SpawnObject();
        }

        for (int i = 0; i < 12; i++)
        {
            swordRank[i] = 0;                           //배열 초기화
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

    public void ObjectCollected(int rank)           //검의 단계를 받아올 매개변수 추가
    {
        swordRank[rank - 1]++;                      //현재 검 단계에 해당하는 배열에 숫자 1 추가                     
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

     void Update()                              //머지 될 검이 있는지 판단
    {
        for(int i = 0; i <12; i++)              //단계별 검 갯수 파악
        {
            if(swordRank[i] >= 2 && i <12)      //특정 단계의 검 개수가 2개가 넘어간다면
            {
                swordRank[i] -=2;               //그 단계의 검 개수 -2
                swordRank[i + 1]++;             //다음 단계의 검 개수 1개 추가
            }
        }
    }
}