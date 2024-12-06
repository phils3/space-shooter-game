using UnityEngine;

public class HealPickup : MonoBehaviour
{
    public int healAmount = 20; // Mennyi HP-t gyógyítson
    public GameObject pickupEffect; // (Opcionális) effekt, ami a pickupkor megjelenik

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellenõrzés, hogy a játékos szedte-e fel
        if (collision.CompareTag("Player"))
        {
            // Keressük a PlayerHealth komponenst
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Növeljük a játékos életerejét
                playerHealth.Heal(healAmount);
            }

            // (Opcionális) Pickup effekt lejátszása
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            // Töröljük a gyógyító tárgyat
            Destroy(gameObject);
        }
    }
}
