using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 200f; 

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float xRotationSpeed = -rotationSpeed * Time.deltaTime; 
            transform.Rotate(xRotationSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float xRotationSpeed = rotationSpeed * Time.deltaTime; 
            transform.Rotate(xRotationSpeed, 0, 0);
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
