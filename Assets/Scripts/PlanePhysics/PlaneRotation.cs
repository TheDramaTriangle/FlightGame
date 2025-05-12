

using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    public float rotationSpeed = 120f;
    public float smoothTime = 0.05f;

    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        float xRotation = 0f;
        float yRotation = 0f;
        float zRotation = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            xRotation = -rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            xRotation = rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            zRotation = -rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            zRotation = rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            yRotation = -rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            yRotation = rotationSpeed * Time.deltaTime;
        }

        // Update the target rotation based on input
        targetRotation *= Quaternion.Euler(xRotation, yRotation, zRotation);

        // Smoothly interpolate to the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothTime);
    }
}
