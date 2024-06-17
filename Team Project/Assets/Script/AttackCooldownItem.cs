using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCooldownItem : MonoBehaviour
{
    public float cooldownReduction = 0.5f;
    private ObjectManagerAttackSpeedItem objectManagerAttackSpeedItem;

    void Start()
    {
        objectManagerAttackSpeedItem = FindObjectOfType<ObjectManagerAttackSpeedItem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ReduceAttackCooldown(cooldownReduction);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Player"))
        {
            objectManagerAttackSpeedItem.ObjectCollected();
            Destroy(gameObject);
        }
    }
}
