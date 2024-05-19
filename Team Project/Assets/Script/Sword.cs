using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private ObjectManager objectManager;

    void Start()
    {
        objectManager = FindObjectOfType<ObjectManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectManager.ObjectCollected();
            Destroy(gameObject);
        }
    }
}
