using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    private float initialSize;
    private int i = 0;
    private int jumpsRemaining = 2; // Variable para llevar un seguimiento de los saltos restantes
    private bool floored;
    private bool invincible = false; // Variable para rastrear si el jugador es invencible
    private float invincibilityDuration = 6f; // Duración de la invencibilidad en segundos

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        Jump();
        Duck();
    }

    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0) // Comprobar si hay saltos restantes
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                jumpsRemaining--; // Reducir los saltos restantes después de saltar
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining == 1) // Permitir el doble salto cuando hay un salto restante
        {
            rb.velocity = Vector3.zero; // Reiniciar la velocidad para un mejor control del doble salto
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jumpsRemaining--; // Reducir los saltos restantes después de saltar
        }
    }

    private void Duck()
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (i == 0)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                if (rb.transform.localScale.y != initialSize)
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);         
                    i = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                float fastFallForce = 20f; // Velocidad aumentada del impulso hacia abajo

                rb.AddForce(new Vector3(0, -fastFallForce, 0), ForceMode.Impulse);
            }
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }

        if (collision.gameObject.CompareTag("Ovni"))
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = true;
            jumpsRemaining = 2; // Restaurar los saltos restantes cuando toca el suelo
        }
    }

    // Método para activar la invencibilidad del jugador
    public void ActivateInvincibility(float duration)
    {
        if (!invincible)
        {
            invincible = true; // Establecer el jugador como invencible
            Invoke("DeactivateInvincibility", invincibilityDuration); // Desactivar la invencibilidad después de la duración especificada
        }
    }

    // Método para desactivar la invencibilidad del jugador
    private void DeactivateInvincibility()
    {
        invincible = false; // Restablecer el jugador como no invencible
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            floored = false;
        }
    }
}
