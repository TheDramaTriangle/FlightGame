

using UnityEngine;

/// <summary>
/// If the enemy is touching the defense object, deal damageAmount to the defense object
/// at a set time interval 
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    public float attackCoolDown = 1f;  
    public int damageAmount = 10; 
    private GameObject defenseTarget = null; 
    private float lastAttackTime = 0f;

    private void OnCollisionStay(Collision collision)
    {
        if (Time.time - lastAttackTime < attackCoolDown) return;

        if (collision.gameObject.CompareTag("Defense"))
        {
            defenseTarget = collision.gameObject; 
            defenseTarget.GetComponent<DefenseHealth>().TakeDamage(damageAmount);
            lastAttackTime = Time.time; 
        }

    }
}
// using System;
// using UnityEngine;

// public class EnemyAttack : MonoBehaviour
// {
//     public float attackCoolDown = 1f;
//     public int   damageAmount   = 10;
//     public AntAnimation animation;

//     private float lastAttackTime = 0f;
//     public event Action OnAttack;
//     public Collider DetectSphere;

//     private void OnCollisionStay(Collision collision)
//     {
//         if (Time.time - lastAttackTime < attackCoolDown) 
//             return;

//         if (collision.gameObject.CompareTag("Defense"))
//         {
//             // fire animation event
//             Debug.Log (name+"~ Trying to attack");
//             OnAttack?.Invoke();
//             animation.HandleAttack();

//             // deal damage
//             collision.gameObject.GetComponent<DefenseHealth>()
//                       .TakeDamage(damageAmount);
//             lastAttackTime = Time.time;
//         }
//     }

//     private void Start (){
//         animation = GetComponent<AntAnimation>();
//     }
// }
