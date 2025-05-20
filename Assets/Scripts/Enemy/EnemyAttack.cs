

// using UnityEngine;

// /// <summary>
// /// If the enemy is touching the defense object, deal damageAmount to the defense object
// /// at a set time interval 
// /// </summary>
// public class EnemyAttack : MonoBehaviour
// {
//     public float attackCoolDown = 1f;  
//     public int damageAmount = 10; 
//     private GameObject defenseTarget = null; 
//     private float lastAttackTime = 0f;

//     private void OnCollisionStay(Collision collision)
//     {
//         if (Time.time - lastAttackTime < attackCoolDown) return;

//         if (collision.gameObject.CompareTag("Defense"))
//         {
//             defenseTarget = collision.gameObject; 
//             defenseTarget.GetComponent<DefenseHealth>().TakeDamage(damageAmount);
//             lastAttackTime = Time.time; 
//         }

//     }
// }
using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackCoolDown = 1f;
    public int   damageAmount   = 10;
    public AntAnimation animation;

    private float lastAttackTime = 0f;
    public event Action OnAttack;
    public UnityEngine.AI.NavMeshAgent NavAgent;
    public float tolerance = 2f; //distance at which the attacking animation trigers
    public EnemyChaser targetFinder;

    private void Update()
    {
        if (NavAgent.remainingDistance < tolerance)
        {
            NavAgent.isStopped = true;
            lastAttackTime += Time.deltaTime;
            if (attackCoolDown - lastAttackTime < 0f)
            {
                // fire animation event
                lastAttackTime = 0.0f;
                OnAttack?.Invoke();
                animation.HandleAttack();
                // deal damage
                targetFinder.target.gameObject.GetComponent<DefenseHealth>()
                        .TakeDamage(damageAmount);
            }
        }
        else
        {
            NavAgent.isStopped = false;
        }
    }

    private void Start (){
        NavAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        targetFinder = GetComponent<EnemyChaser>();
        animation = GetComponent<AntAnimation>();
    }
}
