using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Mozgási sebesség
    private Vector2 screenBounds; // Képernyõ határok

    void Start()
    {
        // Kiszámítjuk a képernyõ határait a kamera alapján
        Camera mainCamera = Camera.main;
        screenBounds = new Vector2(
            mainCamera.orthographicSize * mainCamera.aspect,
            mainCamera.orthographicSize
        );
    }

    void Update()
    {
        // Játékos mozgás
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(moveX, moveY, 0);

        // A képernyõhatárok ellenõrzése
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -screenBounds.x+1, screenBounds.x-1);
        pos.y = Mathf.Clamp(pos.y, -screenBounds.y+1, screenBounds.y-1);
        transform.position = pos;
    }
}
