using System;
using UnityEngine;
using UnityEngine.UI; 

public class EnemyHealth : MonoBehaviour
{
    const int maxHealth = 100; 
    public int health;
    public event Action OnDeath;
    public Image healthBar; 

    // optional: set this in inspector if you don't want to
    // hard-code the death clip length
    public float deathDelay = 1f; 

    public void Start()
    {
        health = maxHealth; 
        updateHealthBar();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        updateHealthBar(); 
        if (health <= 0)
        {
            // notify animation controller
            OnDeath?.Invoke();

            // delay actual destruction to let the death animation play
            Destroy(gameObject, deathDelay);
        }
    }

    public void updateHealthBar()
    {
        if (healthBar != null)  
            healthBar.fillAmount = (float)health / (float)maxHealth;
    }
}
