using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log("Player Health: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("Player Died");

        StartCoroutine(DieCoroutine());
    }

    IEnumerator DieCoroutine()
    {
        
        yield return new WaitForSeconds(1.0f);


        SceneManager.LoadScene("DieScene");
    }
}


