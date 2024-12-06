using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f; // Az ellenség kezdõ életereje
    public GameObject deathEffect; // Halál effektus (opcionális)

    // Sebzés alkalmazása
    public void TakeDamage(float damage)
    {
        health -= damage;  // Csökkenti az életet a sebzés mértékével

        if (health <= 0f)
        {
            Die();  // Ha az élet 0 vagy alá csökken, meghal
            Debug.Log("meghalt");
        }
    }

    // Halál logika
    private void Die()
    {
        if (deathEffect != null)
        {
            // Ha van halál effekt, lejátszódik
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // Az ellenség eltûnik
    }
}
