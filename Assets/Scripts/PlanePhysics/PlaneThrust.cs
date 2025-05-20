using UnityEditor;
using UnityEngine;

/* 
    Thrust keeps the plane moving in the forward 
    direction at a constant speed 
*/
public class PlaneThrust : MonoBehaviour
{
    Rigidbody rb; 
    public float speed = 20; 

    void Start() 
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        float real_speed = speed; 
        if (Input.GetKey(KeyCode.W))
        {
            real_speed += 10;; 
        }

        rb.linearVelocity = transform.forward * real_speed; 
    }
}
