using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    private float distance = 0;

    public List<GameObject> objects; // Lista de GameObjects que contienen el script Parallax

    private List<Parallax> parallaxScripts = new List<Parallax>(); // Lista para almacenar los scripts Parallax

    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString("F0"); // Mostrar el valor inicial sin decimales
        gameOverText.gameObject.SetActive(false);

        // Obtener y almacenar los scripts Parallax de los GameObjects en la lista
        foreach (GameObject obj in objects)
        {
            Parallax parallaxScript = obj.GetComponent<Parallax>();
            if (parallaxScript != null)
            {
                parallaxScripts.Add(parallaxScript);
            }
        }
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + distance.ToString("F0"); // Mostrar la distancia sin decimales
            gameOverText.gameObject.SetActive(true);

            // Desactivar el efecto de parallax para todos los objetos en la lista
            foreach (Parallax parallaxScript in parallaxScripts)
            {
                parallaxScript.enabled = false;
            }
        }
        else
        {
            distance += Time.deltaTime;
            distanceText.text = distance.ToString("F0"); // Mostrar la distancia sin decimales
        }
    }
}