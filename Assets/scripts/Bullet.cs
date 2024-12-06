using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f; // A l�ved�k �lettartama m�sodpercekben
    public int damage = 10; // A l�ved�k �ltal okozott sebz�s

    void Start()
    {
        // A l�ved�k automatikusan elt�nik az �lettartam lej�rta ut�n
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ellen�rizd, hogy az eltal�lt objektum rendelkezik-e "Health" komponenssel
            PlayerHealth targetHealth = collision.GetComponent<PlayerHealth>();
            if (targetHealth != null)
            {
                // Cs�kkentj�k az �leter�t a sebz�s �rt�k�vel
                targetHealth.TakeDamage(damage);
            }

            // A l�ved�k elt�nik az �tk�z�s ut�n
            Destroy(gameObject);
        }
            

        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Sebz�s alkalmaz�sa
            }
            Destroy(gameObject); // L�ved�k t�rl�se
        }
    }
}
