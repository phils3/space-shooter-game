using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f; // A lövedék élettartama másodpercekben
    public int damage = 10; // A lövedék által okozott sebzés

    void Start()
    {
        // A lövedék automatikusan eltûnik az élettartam lejárta után
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ellenõrizd, hogy az eltalált objektum rendelkezik-e "Health" komponenssel
            PlayerHealth targetHealth = collision.GetComponent<PlayerHealth>();
            if (targetHealth != null)
            {
                // Csökkentjük az életerõt a sebzés értékével
                targetHealth.TakeDamage(damage);
            }

            // A lövedék eltûnik az ütközés után
            Destroy(gameObject);
        }
            

        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Sebzés alkalmazása
            }
            Destroy(gameObject); // Lövedék törlése
        }
    }
}
