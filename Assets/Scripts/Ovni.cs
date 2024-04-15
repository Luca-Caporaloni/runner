using UnityEngine;

public class Ovni : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisi�n es con una bala
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destruir el OVNI
            Destroy(gameObject);
        }
    }
}
