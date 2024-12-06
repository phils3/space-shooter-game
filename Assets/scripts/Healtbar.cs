using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthFillImage; // Az Image, amely a kit�lt�tt �letet mutatja

    public void SetHealth(float currentHealth, float maxHealth)
    {
        // Az aktu�lis �let ar�ny�t sz�m�tjuk ki, �s alkalmazzuk a fill amount-ra
        healthFillImage.fillAmount = currentHealth / maxHealth;
    }
}
