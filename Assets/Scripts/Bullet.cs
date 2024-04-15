using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string targetTag = "Ovni"; // Tag del objeto que la bala puede eliminar

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected: " + collision.gameObject.name);

        // Verificar si la colisi�n es con una bala
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destruir el OVNI
            Destroy(gameObject);
        }
    }
}