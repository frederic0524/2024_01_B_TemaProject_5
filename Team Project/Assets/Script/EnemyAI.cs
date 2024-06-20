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
    private Slider healthSlider; // ü�¹� UI Slider

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthSlider = GetComponentInChildren<Slider>(); // �ڽ� ������Ʈ���� Slider ã��
        UpdateHealthUI(); // ������ �� ü�¹� UI �ʱ�ȭ
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
        UpdateHealthUI(); // ü���� ������ ������ ü�¹� UI ������Ʈ
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
        yield return new WaitForSeconds(1.0f); // ���� �ð� ���
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
        float duration = 0.5f; // ü�¹ٰ� ����Ǵ� �ð� (��)
        float startValue = healthSlider.value;
        float endValue = (float)currentHealth / maxHealth;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            healthSlider.value = Mathf.Lerp(startValue, endValue, timer / duration);
            yield return null;
        }

        healthSlider.value = endValue; // ���� ���� �����Ͽ� �ε巴�� ������
    }
}
