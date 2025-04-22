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
        rb.linearVelocity = transform.forward * speed; 
    }
}
