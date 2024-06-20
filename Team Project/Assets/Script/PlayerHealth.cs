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
        Debug.Log("플레이어 체력: " + currentHealth);

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
        Debug.Log("플레이어 체력: " + currentHealth);

        UpdateHealthUI(); // 체력이 증가하면 UI를 업데이트합니다.
    }

    void Die()
    {
        Debug.Log("플레이어 사망");

        StartCoroutine(DieCoroutine());
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
