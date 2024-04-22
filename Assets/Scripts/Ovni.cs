using UnityEngine;

public class Ovni : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisi�n es con una bala
        if (other.CompareTag("Bullet"))
        {
            // Destruir la bala
            Destroy(other.gameObject);

            // Destruir el OVNI
            Destroy(gameObject);
        }
    }
}
