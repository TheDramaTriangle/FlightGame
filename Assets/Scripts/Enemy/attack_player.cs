// using UnityEngine;

// public class FlyingEnemyAI : MonoBehaviour
// {
//     public Transform player;
//     public float speed = 15f;
//     public int player_health = 100;
//     public float detectionRange = 200f;
//     public float stoppingDistance = 0.01f;

//     private void Update()
//     {
//         float distance = Vector3.Distance(transform.position, player.position);
//         if (distance <= detectionRange && distance > stoppingDistance)
//         {
//             Vector3 direction = (player.position - transform.position).normalized;
//             transform.position += direction * speed * Time.deltaTime;

//             // Optional: look at the player
//             transform.rotation = Quaternion.LookRotation(direction);
//         }
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         Debug.Log("test");
//         if (other.CompareTag("Player"))
//         {
//             PlayerHealth.Instance.TakeDamage(10);
//         }
//     }
// }

using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 15f;
    public float detectionRange = 100f;
    public float stoppingDistance = 0.01f;

    public float wanderSpeed = 6f;
    public float wanderRadius = 100f;
    public float directionChangeInterval = 3f;
    public Transform centerPoint;

    private Vector3 wanderDirection;
    private float directionTimer;
    private bool chasingPlayer = false;

    private void Start()
    {
        if (centerPoint == null)
            centerPoint = transform; // Default to starting position

        PickNewWanderDirection();
    }

    private void Update()
    {
        if (player == null)
            return; 

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if player is within detection range
        chasingPlayer = distanceToPlayer <= detectionRange;

        if (chasingPlayer && distanceToPlayer > stoppingDistance)
        {
            ChasePlayer();
        }
        else if (!chasingPlayer)
        {
            Wander();
        }
    }

    private void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Wander()
    {
        directionTimer -= Time.deltaTime;

        Vector3 nextPosition = transform.position + wanderDirection * wanderSpeed * Time.deltaTime;

        if (Vector3.Distance(nextPosition, centerPoint.position) <= wanderRadius)
        {
            transform.position = nextPosition;
            transform.rotation = Quaternion.LookRotation(wanderDirection);
        }
        else
        {
            PickNewWanderDirection(); // Re-pick if going too far
        }

        if (directionTimer <= 0f)
        {
            PickNewWanderDirection();
        }
    }

    private void PickNewWanderDirection()
    {
        for (int i = 0; i < 10; i++) // Try to find a valid direction
        {
            Vector3 randomDir = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-0.3f, 0.3f), // Optional: limit vertical wandering
                Random.Range(-1f, 1f)
            ).normalized;

            Vector3 projectedPosition = transform.position + randomDir * wanderSpeed * directionChangeInterval;

            if (Vector3.Distance(projectedPosition, centerPoint.position) <= wanderRadius)
            {
                wanderDirection = randomDir;
                directionTimer = directionChangeInterval;
                return;
            }
        }

        // Fallback
        wanderDirection = (centerPoint.position - transform.position).normalized;
        directionTimer = directionChangeInterval;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }
}
