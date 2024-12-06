using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Mozg�si sebess�g
    private Vector2 screenBounds; // K�perny� hat�rok

    void Start()
    {
        // Kisz�m�tjuk a k�perny� hat�rait a kamera alapj�n
        Camera mainCamera = Camera.main;
        screenBounds = new Vector2(
            mainCamera.orthographicSize * mainCamera.aspect,
            mainCamera.orthographicSize
        );
    }

    void Update()
    {
        // J�t�kos mozg�s
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(moveX, moveY, 0);

        // A k�perny�hat�rok ellen�rz�se
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -screenBounds.x+1, screenBounds.x-1);
        pos.y = Mathf.Clamp(pos.y, -screenBounds.y+1, screenBounds.y-1);
        transform.position = pos;
    }
}
