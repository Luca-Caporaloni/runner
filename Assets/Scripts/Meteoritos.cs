using System.Collections.Generic;
using UnityEngine;

public class Meteoritos : MonoBehaviour
{
    public List<GameObject> meteorites; // Lista de meteoritos
    public float spawnInterval = 4f; // Intervalo de tiempo entre la generaci�n de meteoritos
    public Vector3 spawnOffset = new Vector3(0f, 10f, 0f); // Offset para la posici�n de generaci�n (para que los meteoritos caigan desde arriba)
    public float minMeteoriteSpeed = 1f; // Velocidad m�nima de ca�da de los meteoritos
    public float maxMeteoriteSpeed = 3f; // Velocidad m�xima de ca�da de los meteoritos

    private float timer = 0f;

    void Start()
    {
        // Comenzar la generaci�n de meteoritos
        InvokeRepeating("SpawnMeteorite", 0f, spawnInterval);
    }

    void Update()
    {
        // No es necesario realizar cambios en Update() para la generaci�n de meteoritos
    }

    private void SpawnMeteorite()
    {
        // Generar un meteorito aleatorio desde arriba
        Vector3 spawnPosition = transform.position + spawnOffset;
        GameObject meteorite = Instantiate(meteorites[Random.Range(0, meteorites.Count)], spawnPosition, Quaternion.identity);

        // Configurar la velocidad de ca�da del meteorito
        Rigidbody meteoriteRb = meteorite.GetComponent<Rigidbody>();
        if (meteoriteRb != null)
        {
            // Generar una direcci�n de ca�da aleatoria
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), -1f, Random.Range(-1f, 1f)).normalized;
            // Generar una velocidad de ca�da aleatoria entre los valores m�nimo y m�ximo
            float randomSpeed = Random.Range(minMeteoriteSpeed, maxMeteoriteSpeed);

            meteoriteRb.velocity = randomDirection * randomSpeed;
        }
    }
}