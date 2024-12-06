using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int damage = 20; // Sebzés, amit a meteor okoz a játékosnak
    
    //void Start()
    //{
    //    Vector2 position = transform.position;

    //    position = new Vector2(position.x, position.y - 1 * Time.deltaTime);
    //    transform.position = position;
    //}

    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Ha a meteor ütközik a játékos objektummal
        if (other.CompareTag("Player"))
        {
            // Megkeressük a PlayerHealth scriptet, hogy alkalmazzuk a sebzést
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("ütközés");
                Animator playerAnimator = other.GetComponent<Animator>();
                if (playerAnimator != null)
                {
                    playerAnimator.SetTrigger("Hit"); // Elindítja a játékos hit animációját
                    Debug.Log("Triggering 'Hit' animation");
                }
                else
                {
                    Debug.LogError("Animator nem található a játékos objektumán!");
                }
            }

            // Eltávolítjuk a meteort, miután ütközik a játékossal
            Destroy(gameObject);
        }
    }
}
