using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // A lövedék prefabja
    public Transform[] firePoints; // Több tűzpont (ágyú) helye
    public float bulletSpeed = 10f; // A lövedék sebessége
    public float fireRate = 0.5f; // Lövések közötti idő (másodperc)

    private float fireCooldown = 0f; // A következő lövésig hátralévő idő

    void Update()
    {
        // Csökkentjük a cooldown értékét
        fireCooldown -= Time.deltaTime;

        // Ha a Space gomb le van nyomva, és a cooldown lejárt, lövünk
        if (Input.GetKey(KeyCode.Space) && fireCooldown <= 0f)
        {
            Fire();
            fireCooldown = fireRate; // Újratöltési idő beállítása
        }
    }

    public void Fire()
    {
        // Az összes tűzpontból (ágyúból) tüzel
        foreach (Transform firePoint in firePoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.up * bulletSpeed; // Felfelé mozgatás
            }
        }
    }
}
