
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlaneShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; 
    public float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
            EventManager.Notify<GameEvent.PlaneShoot>();

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
