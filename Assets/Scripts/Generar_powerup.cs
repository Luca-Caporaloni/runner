using System.Collections.Generic;
using UnityEngine;

public class Generar_powerup : MonoBehaviour
{
    public List<GameObject> powerup;
    public GameObject instantiatePos;
    public float respawningTimer;
    private float time = 0;

    void Start()
    {
        Invencibilidad.powerUpVelocity = 0.5f;
    }

    void Update()
    {
        SpawnPowerUp();
        ChangeVelocity();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 4f, time / 100f);
    }

    private void SpawnPowerUp()
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(powerup[UnityEngine.Random.Range(0, powerup.Count)], instantiatePos.transform);
            respawningTimer = UnityEngine.Random.Range(2, 4);
        }
    }
}
