using UnityEngine;
using System.Collections;
public class EnemyBehavior : MonoBehaviour
{
    public float speed = 1f; // Mozg�si sebess�g
    public GameObject bulletPrefab; // L�ved�k prefab
    public Transform[] firePoints; // Az �gy�k helyei
    public float shootInterval = 2f; // Lővési idököz
    public float destory_time = 3f;
    private float shootTimer=0f;
    public float bulletSpeed = 5f;
    private Rigidbody2D rb;
    void Start()
    {
        
       
    }
    void Update()
    {
        //lefelé mozgás
        Vector2 position = transform.position;

        position=new Vector2 (position.x, position.y-speed *  Time.deltaTime);
        transform.position = position;
        //Debug.Log("pozicio: " + position);
        // Lövés időzítése
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            
            Shoot(); // Lövés meghívása
            shootTimer = 0f; // Időzítő alaphelyzetbe állítása
        }
    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            // Lövedék létrehozása
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Mozgás hozzáadása a lövedékhez
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.down * bulletSpeed; // Lefelé mozgatás
            }
        }
    }

    private void OnBecameInvisible()
    {
        // Objektum t�rl�se, ha elhagyja a k�perny�t
        Destroy(gameObject,destory_time);
    }
}
