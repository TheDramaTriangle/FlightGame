using UnityEngine;

public class DefenseHealth : MonoBehaviour
{
    public int health = 500; 

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
