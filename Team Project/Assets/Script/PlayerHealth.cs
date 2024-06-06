using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // 최대 체력
    public int currentHealth; // 현재 체력

    public Text healthText; // UI Text 요소를 연결할 변수

    void Start()
    {
        currentHealth = maxHealth; // 시작할 때 최대 체력으로 초기화
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "체력: " + currentHealth.ToString(); // 현재 체력을 UI Text에 반영
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // 공격 받은 만큼 체력 감소

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하면 플레이어 사망 처리
        }
    }

    void Die()
    {
        // 플레이어 사망 시 처리할 로직 추가
    }
}
