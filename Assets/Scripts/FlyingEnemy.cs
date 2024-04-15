using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject bulletPrefabEnemy;
    public Transform firePoint;
    public float bulletForce = 20f;
    public float fireRate = 2f; // Velocidad de disparo en segundos
    private float nextFireTime;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefabEnemy, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}