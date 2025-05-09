
using UnityEngine;

public class PlaneShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; 
    public float bulletSpeed = 20f;
    public float bulletCooldown = 0.2f; 
    private float lastShootTime = 0f; 

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (Time.time - lastShootTime >= bulletCooldown)
            {
                Shoot();
                EventManager.Notify<GameEvent.PlaneShoot>();
                lastShootTime = Time.time; 
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(90, 0, 0);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
}
