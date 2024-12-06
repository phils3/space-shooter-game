using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthFillImage; // Az Image, amely a kitöltött életet mutatja

    public void SetHealth(float currentHealth, float maxHealth)
    {
        // Az aktuális élet arányát számítjuk ki, és alkalmazzuk a fill amount-ra
        healthFillImage.fillAmount = currentHealth / maxHealth;
    }
}
