using System;
using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float fallSpeed = 25f;

    public float smoothTime = 0.04f;
    public float turnSpeed = 10f;

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

        PlayerHealth playerHealth = GetComponent<PlayerHealth>();

        if (playerHealth.IsDead)
        {
            xRotation = -fallSpeed * Time.deltaTime;
        }
        else
        {
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
                yRotation = rotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                yRotation = -rotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                zRotation = rotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                zRotation = -rotationSpeed * Time.deltaTime;
            }
        }

        // Update the target rotation based on input
        targetRotation *= Quaternion.Euler(xRotation, yRotation, zRotation);

        // Smoothly interpolate to the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothTime);
    }
}
