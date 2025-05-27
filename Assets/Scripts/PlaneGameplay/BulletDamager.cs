using UnityEngine;

public class BulletDamager : MonoBehaviour
{
    public int bulletDamage = 10; 
    public GameObject explosionEffect; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject; 
            enemy.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        }
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
