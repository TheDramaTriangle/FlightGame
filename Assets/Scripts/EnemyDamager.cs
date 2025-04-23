using UnityEngine;

/// <summary>
/// If the enemy is touching the defense object, deal damageAmount to the defense object
/// at a set time interval 
/// </summary>
public class EnemyDamager : MonoBehaviour
{
    public float damageInterval = 1f;  
    public int damageAmount = 10; 
    private float damageTimer = 0f; 
    private bool isTouchingDefense = false; 
    private GameObject defenseTarget = null; 

    void Update()
    {
        if (isTouchingDefense && defenseTarget != null)
        {
            damageTimer -= Time.deltaTime; 
            if (damageTimer <= 0f)
            {
                if (defenseTarget != null)
                {
                    defenseTarget.GetComponent<DefenseHealth>().TakeDamage(damageAmount);
                }
                damageTimer = damageInterval; 
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Defense"))
        {
            isTouchingDefense = true; 
            defenseTarget = collision.gameObject; 
            damageTimer = damageInterval;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Defense"))
        {
            isTouchingDefense = false; 
            defenseTarget = null; 
        }
    }
}


