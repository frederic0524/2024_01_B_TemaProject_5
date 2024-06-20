using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider = GetComponentInChildren<Slider>();
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("�÷��̾� ü��: " + currentHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log("�÷��̾� ü��: " + currentHealth);

        UpdateHealthUI(); // ü���� �����ϸ� UI�� ������Ʈ�մϴ�.
    }

    void Die()
    {
        Debug.Log("�÷��̾� ���");

        StartCoroutine(DieCoroutine());
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

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            StartCoroutine(UpdateHealthSliderSmoothly());
        }
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("DieScene");
    }
}
