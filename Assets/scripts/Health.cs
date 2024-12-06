using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maxim�lis �leter�
    private int currentHealth; // Aktu�lis �leter�
    private Animator anim;
    public TextMeshProUGUI healtText;
    public float invincibilityTime = 1f; // Id�, am�g a j�t�kos invincible (p�ld�ul, miut�n eltal�lt�k)
    private float invincibilityTimer = 0f;
    //healtbar referencia
    public HealthBar healthBar;
    // Hal�lmen� canvas referencia
    public GameObject deathMenuCanvas;
    void Start()
    {
        // Kezdeti �leter� be�ll�t�sa
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        healtText.text = currentHealth.ToString();
        // Friss�tj�k a health bar-t
        healthBar.SetHealth(currentHealth, maxHealth);
    }

    void Update()
    {
        // Invincibility id� cs�kkent�se
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }

    }
    // A j�t�kos gy�gy�t�sa (haszn�lhat�, ha van gy�gy�t� objektum)
    public void Heal(int amount)
    {
        if (currentHealth + amount < maxHealth)
        {
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ne l�pje t�l a maxHealth �rt�ket
            healthBar.SetHealth(currentHealth, maxHealth); // Friss�ti a health bar-t
            healtText.text = currentHealth.ToString(); // Friss�ti a health sz�veget
        }
        else currentHealth = 100;
    }
    // Sebz�s alkalmaz�sa a j�t�kosra
    public void TakeDamage(int damage)
    {

        if (invincibilityTimer <= 0) // Csak akkor sebezhet�, ha nem invincible
        {
            if (currentHealth - damage > 0)
            {
                currentHealth -= damage;
                // Biztos�tjuk, hogy ne menjen negat�vba
                currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
                // Friss�tj�k a health bar-t
                healthBar.SetHealth(currentHealth, maxHealth);
                //healt text
                healtText.text = currentHealth.ToString();
                //hit anim�ci� elindit�sa
                anim.SetTrigger("Hit");
            }
            //else if (currentHealth <= 0)
            //{
            //    Die();
            //}


            else
            {
                // Ha a j�t�kos megkapott sebz�st, invincible lesz egy ideig
                invincibilityTimer = invincibilityTime;
                healthBar.SetHealth(0, maxHealth);
                healtText.text = "0";
                Die();

            }
        }
    }

    // A j�t�kos hal�la
    void Die()
    {
        Debug.Log("Player has died!");

        // J�t�k meg�ll�t�sa
        Time.timeScale = 0f; // A j�t�k le�ll�t�sa

        // Hal�lmen� aktiv�l�sa
        if (deathMenuCanvas != null)
        {
            deathMenuCanvas.SetActive(true);
        }

        // A j�t�kos t�rl�se vagy hal�l kezel�se
        Destroy(gameObject); // Ez t�rli a j�t�kos objektumot
    }
}

   
