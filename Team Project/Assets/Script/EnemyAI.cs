using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public float moveSpeed = 3f;
    public float attackRate = 2f;
    public int attackDamage = 15;
    public int health = 100;

    private Rigidbody rb;
    private float nextAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 move = direction * moveSpeed * Time.deltaTime;

            rb.MovePosition(transform.position + move);

            if (distance <= attackRadius && Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy health: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        Debug.Log("Enemy died");

        
        StartCoroutine(DieCoroutine());
    }

    
    IEnumerator DieCoroutine()
    {
        // 일정 시간 대기
        yield return new WaitForSeconds(1.0f); 

        
        SceneManager.LoadScene("EndScene");
    }
}