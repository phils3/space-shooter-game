using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int damage = 20; // Sebz�s, amit a meteor okoz a j�t�kosnak
    
    //void Start()
    //{
    //    Vector2 position = transform.position;

    //    position = new Vector2(position.x, position.y - 1 * Time.deltaTime);
    //    transform.position = position;
    //}

    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Ha a meteor �tk�zik a j�t�kos objektummal
        if (other.CompareTag("Player"))
        {
            // Megkeress�k a PlayerHealth scriptet, hogy alkalmazzuk a sebz�st
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("�tk�z�s");
                Animator playerAnimator = other.GetComponent<Animator>();
                if (playerAnimator != null)
                {
                    playerAnimator.SetTrigger("Hit"); // Elind�tja a j�t�kos hit anim�ci�j�t
                    Debug.Log("Triggering 'Hit' animation");
                }
                else
                {
                    Debug.LogError("Animator nem tal�lhat� a j�t�kos objektum�n!");
                }
            }

            // Elt�vol�tjuk a meteort, miut�n �tk�zik a j�t�kossal
            Destroy(gameObject);
        }
    }
}
