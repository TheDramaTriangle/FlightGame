
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaser : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void SetNewTarget(Transform newTarget)
    {
        if (newTarget != null)
        {
            agent.SetDestination(newTarget.position);
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
   
}
