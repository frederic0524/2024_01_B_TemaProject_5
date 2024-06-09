using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPitem : MonoBehaviour
{
    public int healAmount = 30;
    private ObjectManagerHPitem objectManager;

    void Start()
    {
        objectManager = FindObjectOfType<ObjectManagerHPitem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Player"))
        {
            objectManager.ObjectCollected();
            Destroy(gameObject);
        }
    }
}


