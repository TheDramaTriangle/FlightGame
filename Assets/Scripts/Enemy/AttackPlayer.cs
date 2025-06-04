using UnityEngine;
using System.Collections.Generic;

public class FlyingEnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 15f;
    public float detectionRange = 25f;
    public float stoppingDistance = 0.01f;
    public float wanderSpeed = 10f;
    public float coolDowninterval = 4f;
    public float coolDown;
    public List<Transform> patrolPoints = new List<Transform>();
    private bool chasingPlayer = false;
    private int currentPatrolIndex = 0;
    public GameObject explosionEffect; 
    public Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        coolDown = 0f;
    }

    private void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if player is within detection range
        chasingPlayer = distanceToPlayer <= detectionRange && coolDown <= 0;

        if (chasingPlayer && distanceToPlayer > stoppingDistance)
        {
            ChasePlayer();
        }
        else if (!chasingPlayer)
        {
            if (coolDown > 0)
            {
                coolDown -= Time.deltaTime;
            }
            Wander();
        }
    }

    private void ChasePlayer()
    {
        Debug.Log("Chasing");
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Wander()
    {
        if (patrolPoints == null || patrolPoints.Count == 0)
            return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];

        // Smooth movement toward the target point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, wanderSpeed * Time.deltaTime);

        // Smooth rotation toward the movement direction
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);
        }

        // Check if close enough to switch to next point
        float distanceToPoint = Vector3.Distance(transform.position, targetPoint.position);
        if (distanceToPoint <= stoppingDistance)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }

        Debug.Log($"Patrolling to {targetPoint.name} - Distance: {distanceToPoint}");
    }
}
