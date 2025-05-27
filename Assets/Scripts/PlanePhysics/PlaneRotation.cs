using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float fallSpeed = 25f;

    void Update()
    {
        if (PlayerHealth.Instance.isDead)
        {
            float xRotationSpeed = -fallSpeed * Time.deltaTime;
            return;
        }
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
        if (Input.GetKey(KeyCode.A))
        {
            float yRotationSpeed = -rotationSpeed * Time.deltaTime; 
            transform.Rotate(0, yRotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            float yRotationSpeed = rotationSpeed * Time.deltaTime; 
            transform.Rotate(0, yRotationSpeed, 0);
        }
    }
}
