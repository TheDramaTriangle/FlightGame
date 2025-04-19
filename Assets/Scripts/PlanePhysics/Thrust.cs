using UnityEditor;
using UnityEngine;

/* 
    Thrust keeps the plane moving in the forward 
    direction at a constant speed 
*/
public class Thrust : MonoBehaviour
{
    Rigidbody rb; 
    public float speed = 5; 

    void Start() 
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * speed; 
    }
}
