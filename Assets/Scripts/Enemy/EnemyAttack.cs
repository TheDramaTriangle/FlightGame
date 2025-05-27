
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
        // Stop attacking if no target remains 
        if (targetFinder.target == null)
            return; 

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
