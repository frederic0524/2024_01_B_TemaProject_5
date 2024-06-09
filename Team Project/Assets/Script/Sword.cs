using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private ObjectManagerSword objectManagerSword;

    void Start()
    {
        objectManagerSword = FindObjectOfType<ObjectManagerSword>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectManagerSword.ObjectCollected();
            Destroy(gameObject);
        }
    }
}
