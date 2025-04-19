using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 200f; 
    // The rotation left and right should both rotate the plane 
    // on the x axis and the y axis. However, the y rotation
    // should be slower. This ratio determines how much slower 
    // relative to rotation speed
    public float rotationRatio = 1/3; 

    void Update()
    {
        // We want the y rotation speed to be slower than x rotation speed 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float xRotationSpeed = -rotationSpeed * Time.deltaTime; 
            float yRotationSpeed = xRotationSpeed * rotationRatio; 
            transform.Rotate(xRotationSpeed, yRotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float xRotationSpeed = rotationSpeed * Time.deltaTime; 
            float yRotationSpeed = xRotationSpeed * rotationRatio; 
            transform.Rotate(xRotationSpeed, yRotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float zRotationSpeed = -rotationSpeed * Time.deltaTime; 
            transform.Rotate(0, 0, zRotationSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float zRotationSpeed = rotationSpeed * Time.deltaTime; 
            transform.Rotate(0, 0, zRotationSpeed);
        }
    }
}
