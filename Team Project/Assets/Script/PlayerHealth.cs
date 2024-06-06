using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // �ִ� ü��
    public int currentHealth; // ���� ü��

    public Text healthText; // UI Text ��Ҹ� ������ ����

    void Start()
    {
        currentHealth = maxHealth; // ������ �� �ִ� ü������ �ʱ�ȭ
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "ü��: " + currentHealth.ToString(); // ���� ü���� UI Text�� �ݿ�
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // ���� ���� ��ŭ ü�� ����

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 ���ϸ� �÷��̾� ��� ó��
        }
    }

    void Die()
    {
        // �÷��̾� ��� �� ó���� ���� �߰�
    }
}
