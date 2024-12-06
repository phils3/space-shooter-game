using UnityEngine;

public class MoovingObjectDown : MonoBehaviour
{
    public float speed = 1f;
   
    // Update is called once per frame
   
    void Update()
    {
       
        //lefelé mozgás
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
    }
}
