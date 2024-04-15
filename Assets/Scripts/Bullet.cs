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
        // Verificar si el objeto con el que choca tiene el tag correcto
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Destruir el objeto con el tag especificado
            Destroy(collision.gameObject);
        }

        // Destruir la bala al chocar con algo
        Destroy(gameObject);
    }
}