using System.Collections;
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
    public int maxHealth = 100;

    private int currentHealth;
    private Rigidbody rb;
    private float nextAttackTime = 0f;
    private Slider healthSlider; // 체력바 UI Slider

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthSlider = GetComponentInChildren<Slider>(); // 자식 오브젝트에서 Slider 찾기
        UpdateHealthUI(); // 시작할 때 체력바 UI 초기화
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
        currentHealth -= damage;
        UpdateHealthUI(); // 체력이 감소할 때마다 체력바 UI 업데이트
        if (currentHealth <= 0)
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
        yield return new WaitForSeconds(1.0f); // 일정 시간 대기
        SceneManager.LoadScene("EndScene");
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            StartCoroutine(UpdateHealthSliderSmoothly());
        }
    }

    IEnumerator UpdateHealthSliderSmoothly()
    {
        float timer = 0f;
        float duration = 0.5f; // 체력바가 변경되는 시간 (초)
        float startValue = healthSlider.value;
        float endValue = (float)currentHealth / maxHealth;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            healthSlider.value = Mathf.Lerp(startValue, endValue, timer / duration);
            yield return null;
        }

        healthSlider.value = endValue; // 최종 값을 설정하여 부드럽게 마무리
    }
}
