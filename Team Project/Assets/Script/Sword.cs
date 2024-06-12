using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int Rank;            //검의 단계를 나타낼 변수

    private ObjectManagerSword objectManagerSword;

    void Start()
    {
        objectManagerSword = FindObjectOfType<ObjectManagerSword>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectManagerSword.ObjectCollected(Rank);           //검의 단계를 매개변수로 전달
            Destroy(gameObject);
        }
    }
}
