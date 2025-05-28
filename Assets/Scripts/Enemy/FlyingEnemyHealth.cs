using System;
using UnityEngine;

public class FlyingEnemyHealth : MonoBehaviour
{
    public int health = 50;
    public bool IsDead { get; private set; }

    private void Start()
    {
        IsDead = false;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Health: " + health);
        if (health <= 0 && !IsDead)
        {
            IsDead = true;
        }
    }
}
