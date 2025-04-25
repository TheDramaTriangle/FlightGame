using UnityEditor;
using UnityEngine;

/* 
    Thrust keeps the plane moving in the forward 
    direction at a constant speed 
*/
// public class PlaneThrust : MonoBehaviour
// {
//     Rigidbody rb; 
    
//     public float baseAcceleration = 5f;
//     public float maxSpeed = 50f;
//     public float minSpeed = 0f;
//     public float maxThrottleTime = 3f; // How long it takes to reach full acceleration
//     private float throttleHoldTime = 0f;
//     private float letgoTime = 0f;
//     private float currentSpeed = 20f;
//     bool accelerating;

//     void Start() 
//     {
//         rb = GetComponent<Rigidbody>(); 
//     }

//     void Update()
//     {
//         float throttleInput = Input.GetAxis("Vertical");
//         // Holding the throttle key (W)
//         if (throttleInput != 0)
//         {
//             throttleHoldTime += Time.deltaTime;
//             letgoTime = 0;
//             accelerating = true;
            
//         }
//         else
//         {
//             letgoTime += Time.deltaTime;
//             throttleHoldTime = 9;
//             accelerating = false;
//         }

//         // Normalize how long it's held (0 to 1)
//         float throttlePercent = Mathf.Clamp01(throttleHoldTime / maxThrottleTime);

//         // Accelerate based on how long key has been held
//         if (accelerating)
//         {
//             float currentAcceleration = baseAcceleration * throttlePercent;
//             currentSpeed += currentAcceleration * Time.deltaTime;
//             currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
//         }
//         else
//         {
//             float currentDeceleration = baseAcceleration * letgoTime;
//             currentSpeed -= currentDeceleration * Time.deltaTime;
//             currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
//         }

//         Debug.Log("Current speed: " + currentSpeed);
//         rb.linearVelocity = transform.forward * currentSpeed; 
//     }
// }

public class PlaneThrust : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 15f;
    public float acceleration = 0;
    public float max_speed = 30f;
    public float min_speed = 15f;
    public float max_time = 3f; 
    private float throttle_time = 0f;
    private float release_time = 0f;

    void Start() 
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W)))
        {
            throttle_time += Time.deltaTime;
            release_time = 0;
            acceleration = 1.2f * Mathf.Min(max_time,throttle_time);
        }
        else         
        {
            release_time += Time.deltaTime;
            throttle_time = 0;
            acceleration = -1.2f * Mathf.Min(max_time,release_time);
        }
        
        speed += acceleration * 0.01f;
        speed = Mathf.Clamp(speed, min_speed, max_speed);
        Debug.Log("Current speed: " + speed);
        rb.linearVelocity = transform.forward * speed;
    }



}