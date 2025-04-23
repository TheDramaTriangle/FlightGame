using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; 
        if (health < damageAmount)
        {
            Destroy(gameObject);
        }
    }
}
