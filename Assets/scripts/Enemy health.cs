using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f; // Az ellens�g kezd� �letereje
    public GameObject deathEffect; // Hal�l effektus (opcion�lis)

    // Sebz�s alkalmaz�sa
    public void TakeDamage(float damage)
    {
        health -= damage;  // Cs�kkenti az �letet a sebz�s m�rt�k�vel

        if (health <= 0f)
        {
            Die();  // Ha az �let 0 vagy al� cs�kken, meghal
            Debug.Log("meghalt");
        }
    }

    // Hal�l logika
    private void Die()
    {
        if (deathEffect != null)
        {
            // Ha van hal�l effekt, lej�tsz�dik
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // Az ellens�g elt�nik
    }
}
