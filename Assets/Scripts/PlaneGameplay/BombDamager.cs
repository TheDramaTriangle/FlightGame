using UnityEngine;

public class BombDamager: MonoBehaviour
{
    public int bombDamage = 100;
    public int bombRadius = 100;
    public GameObject explosionEffect; 

    void OnCollisionEnter(Collision collision)
    {
        EventManager.Notify<GameEvent.Explosion>(); 
        Explode(); 
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, bombRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<EnemyHealth>(out var enemy))
            {
                enemy.TakeDamage(bombDamage);
            }
        }
        Destroy(gameObject);
    }
}


