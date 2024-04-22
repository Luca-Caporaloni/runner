using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generar_powerup : MonoBehaviour
{
    public List<GameObject> powerUps; // Lista de prefabs de power-ups
    public float spawnInterval = 10f; // Intervalo de tiempo entre la generación de power-ups
    public float spawnRadius = 5f; // Radio dentro del cual se generarán los power-ups
    public float powerUpSpeed = 2f; // Velocidad de movimiento de los power-ups

    void Start()
    {
        // Comenzar la generación de power-ups
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            // Generar una posición aleatoria dentro del radio especificado
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            // Seleccionar un power-up aleatorio de la lista
            GameObject powerUpPrefab = powerUps[Random.Range(0, powerUps.Count)];

            // Instanciar el power-up en la posición generada
            GameObject powerUpInstance = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);

            // Obtener el componente Rigidbody del power-up instanciado
            Rigidbody powerUpRb = powerUpInstance.GetComponent<Rigidbody>();

            // Asignar una velocidad de movimiento al power-up
            if (powerUpRb != null)
            {
                // Calcular una dirección de movimiento aleatoria
                Vector3 randomDirection = Random.insideUnitSphere.normalized;
                // Asignar la velocidad de movimiento al power-up
                powerUpRb.velocity = randomDirection * powerUpSpeed;
            }

            // Esperar hasta el próximo intervalo de generación
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}