using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public float bulletLifetime = 2f; // Tiempo de vida de la bala


    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" al bot�n que quieras usar para disparar
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

        Destroy(bullet, bulletLifetime); // Destruye la bala despu�s de bulletLifetime segundos
    }
}
