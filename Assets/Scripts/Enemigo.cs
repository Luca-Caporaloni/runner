using UnityEngine;

public class Enemigo : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisi�n es con una bala
        if (other.CompareTag("Player"))
        {
            // Destruir la bala
            Destroy(other.gameObject);
            Controller_Hud.gameOver = true;
        }
    }
}

