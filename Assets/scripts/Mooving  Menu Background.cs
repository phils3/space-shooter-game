using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1f; // Mozgás sebessége
    public float resetPositionY = 10f; // Kezdeti pozíció Y koordinátája
    public float lowerLimitY = -10f; // Az Y pozíció, amikor újraindul

    void Update()
    {
        // A szülõ elem lefelé mozgatása
        transform.position -= new Vector3(0, scrollSpeed * Time.deltaTime, 0);

        // Ha a szülõ elem elér egy adott Y pozíciót, visszaállítjuk az eredeti helyzetére
        if (transform.position.y <= lowerLimitY)
        {
            transform.position = new Vector3(transform.position.x, resetPositionY, transform.position.z);
        }
    }
}
