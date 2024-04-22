using UnityEngine;

public class Invencibilidad : MonoBehaviour
{
    public static float powerUpVelocity;
    public PowerUpType type; // Tipo de power-up (puedes definir diferentes tipos según tus necesidades)
    public float duration = 5f; // Duración del power-up

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener el script del jugador
            Controller_Player player = other.GetComponent<Controller_Player>();
            if (player != null)
            {
                // Activar el power-up en el jugador según su tipo
                switch (type)
                {
                    case PowerUpType.Invincibility:
                        player.ActivateInvincibility(duration);
                        break;
                        // Agrega más casos para otros tipos de power-ups si los necesitas
                }

                // Destruir el power-up
                Destroy(gameObject);
            }
        }
    }
}

// Enumeración para los tipos de power-ups disponibles
public enum PowerUpType
{
    Invincibility,
    // Agrega más tipos de power-ups según sea necesario
}