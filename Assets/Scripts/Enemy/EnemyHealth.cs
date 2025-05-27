// using UnityEngine;

// public class EnemyHealth : MonoBehaviour
// {
//     public int health; 
//     // Start is called once before the first execution of Update after the MonoBehaviour is created

//     public void TakeDamage(int damageAmount)
//     {
//         health -= damageAmount; 
//         if (health < damageAmount)
//         {
//             Destroy(gameObject);
//         }
//     }
// }

using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public event Action OnDeath;

    // optional: set this in inspector if you don't want to
    // hard-code the death clip length
    public float deathDelay = 1f; 

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            // notify animation controller
            OnDeath?.Invoke();

            // delay actual destruction to let the death animation play
            Destroy(gameObject, deathDelay);
        }
    }
}
