using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlaneRotation : MonoBehaviour
// {
//     public float YawAmount = 120;
//     private float Yaw;

//     void Start() {
//     }

//     void Update() {
//         float horizontalInput = Input.GetAxis("Horizontal");
//         float verticalInput = Input.GetAxis("Vertical");

//         Yaw += horizontalInput * YawAmount * Time.deltaTime;
//         float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
//         float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

//         transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);
//     }
// }

public class PlaneRotation : MonoBehaviour
{
    public float YawAmount = 120f;
    public float PitchSpeed = 60f;
    public float RollSpeed = 80f;

    private float yaw;
    private float pitch;

    void Start() {
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        yaw += horizontalInput * YawAmount * Time.deltaTime;
        pitch += -verticalInput * PitchSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -360f, 360f); // Allow full upside down

        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        
        if(pitch == -360 || pitch == 360)
        {
            pitch = 0;
        }
    }
}
