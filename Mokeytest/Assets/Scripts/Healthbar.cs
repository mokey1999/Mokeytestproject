using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (maxHealth <= 0) return;

        float healthPercentage = currentHealth / maxHealth;
        fillImage.fillAmount = Mathf.Clamp01(healthPercentage);
    }
}
