using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffItem : MonoBehaviour
{
    public int damageAmount = 40;
    private ObjectManagerDebuffitem objectManagerDebuffitem;

    void Start()
    {
        objectManagerDebuffitem = FindObjectOfType<ObjectManagerDebuffitem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            objectManagerDebuffitem.ObjectCollected();
            Destroy(gameObject);
        }
    }
}
