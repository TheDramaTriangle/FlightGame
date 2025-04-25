using UnityEngine;

public class BulletDamager : MonoBehaviour
{
    public int bulletDamage = 10; 

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject; 
            enemy.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
