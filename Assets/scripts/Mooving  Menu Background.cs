using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1f; // Mozg�s sebess�ge
    public float resetPositionY = 10f; // Kezdeti poz�ci� Y koordin�t�ja
    public float lowerLimitY = -10f; // Az Y poz�ci�, amikor �jraindul

    void Update()
    {
        // A sz�l� elem lefel� mozgat�sa
        transform.position -= new Vector3(0, scrollSpeed * Time.deltaTime, 0);

        // Ha a sz�l� elem el�r egy adott Y poz�ci�t, vissza�ll�tjuk az eredeti helyzet�re
        if (transform.position.y <= lowerLimitY)
        {
            transform.position = new Vector3(transform.position.x, resetPositionY, transform.position.z);
        }
    }
}
