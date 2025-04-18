using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 200f; 

    void Update()
    {
        // We want the y rotation speed to be slower than x rotation speed 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float xRotationSpeed = -rotationSpeed * Time.deltaTime; 
            float yRotationSpeed = xRotationSpeed / 3; 
            transform.Rotate(xRotationSpeed, yRotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float xRotationSpeed = rotationSpeed * Time.deltaTime; 
            float yRotationSpeed = xRotationSpeed / 3; 
            transform.Rotate(xRotationSpeed, yRotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float zRotationSpeed = -rotationSpeed * Time.deltaTime; 
            transform.Rotate(0, 0, zRotationSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float zRotationSpeed = rotationSpeed * Time.deltaTime; 
            transform.Rotate(0, 0, zRotationSpeed);
        }
    }
}
