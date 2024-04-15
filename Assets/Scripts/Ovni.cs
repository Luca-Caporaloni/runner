using UnityEngine;

public class Ovni : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con una bala
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destruir el OVNI
            Destroy(gameObject);
        }
    }
}
