using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximális életerõ
    private int currentHealth; // Aktuális életerõ
    private Animator anim;
    public TextMeshProUGUI healtText;
    public float invincibilityTime = 1f; // Idõ, amíg a játékos invincible (például, miután eltalálták)
    private float invincibilityTimer = 0f;
    //healtbar referencia
    public HealthBar healthBar;
    // Halálmenü canvas referencia
    public GameObject deathMenuCanvas;
    void Start()
    {
        // Kezdeti életerõ beállítása
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        healtText.text = currentHealth.ToString();
        // Frissítjük a health bar-t
        healthBar.SetHealth(currentHealth, maxHealth);
    }

    void Update()
    {
        // Invincibility idõ csökkentése
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }

    }
    // A játékos gyógyítása (használható, ha van gyógyító objektum)
    public void Heal(int amount)
    {
        if (currentHealth + amount < maxHealth)
        {
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ne lépje túl a maxHealth értéket
            healthBar.SetHealth(currentHealth, maxHealth); // Frissíti a health bar-t
            healtText.text = currentHealth.ToString(); // Frissíti a health szöveget
        }
        else currentHealth = 100;
    }
    // Sebzés alkalmazása a játékosra
    public void TakeDamage(int damage)
    {

        if (invincibilityTimer <= 0) // Csak akkor sebezhetõ, ha nem invincible
        {
            if (currentHealth - damage > 0)
            {
                currentHealth -= damage;
                // Biztosítjuk, hogy ne menjen negatívba
                currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
                // Frissítjük a health bar-t
                healthBar.SetHealth(currentHealth, maxHealth);
                //healt text
                healtText.text = currentHealth.ToString();
                //hit animáció elinditása
                anim.SetTrigger("Hit");
            }
            //else if (currentHealth <= 0)
            //{
            //    Die();
            //}


            else
            {
                // Ha a játékos megkapott sebzést, invincible lesz egy ideig
                invincibilityTimer = invincibilityTime;
                healthBar.SetHealth(0, maxHealth);
                healtText.text = "0";
                Die();

            }
        }
    }

    // A játékos halála
    void Die()
    {
        Debug.Log("Player has died!");

        // Játék megállítása
        Time.timeScale = 0f; // A játék leállítása

        // Halálmenü aktiválása
        if (deathMenuCanvas != null)
        {
            deathMenuCanvas.SetActive(true);
        }

        // A játékos törlése vagy halál kezelése
        Destroy(gameObject); // Ez törli a játékos objektumot
    }
}

   
