using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeditem : MonoBehaviour
{
    public float speedIncreaseAmount = 1f;
    private ObjectManagerSpeeditem objectManagerSpeeditem;

    void Start()
    {
        objectManagerSpeeditem = FindObjectOfType<ObjectManagerSpeeditem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.IncreaseMoveSpeed(speedIncreaseAmount);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Player"))
        {
            objectManagerSpeeditem.ObjectCollected();
            Destroy(gameObject);
        }
    }
}
