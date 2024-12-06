using UnityEngine;

public class HealPickup : MonoBehaviour
{
    public int healAmount = 20; // Mennyi HP-t gy�gy�tson
    public GameObject pickupEffect; // (Opcion�lis) effekt, ami a pickupkor megjelenik

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ellen�rz�s, hogy a j�t�kos szedte-e fel
        if (collision.CompareTag("Player"))
        {
            // Keress�k a PlayerHealth komponenst
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // N�velj�k a j�t�kos �leterej�t
                playerHealth.Heal(healAmount);
            }

            // (Opcion�lis) Pickup effekt lej�tsz�sa
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            // T�r�lj�k a gy�gy�t� t�rgyat
            Destroy(gameObject);
        }
    }
}
