using UnityEngine;

public class CameraFollowPlane : MonoBehaviour
/*
    Set the camera to follow the plane from a third person view 
*/
{
    public Transform playerPlane;  
    public Vector3 offset = new(0, 1, -3); 
    public float smoothSpeed = 3f; 
    public GameObject PlayerPlane; // Drag the PlayerPlane object here in the Inspector
    private PlaneThrust thrustScript;

    public float shakeMagnitude = 0.1f;
    public float shakeSpeed = 1f;

    void Start()
    {
        // Get the PlaneThrust component from the playerPlane
        thrustScript = playerPlane.GetComponent<PlaneThrust>();

        if (thrustScript == null)
        {
            Debug.LogWarning("PlaneThrust component not found on PlayerPlane!");
        }
    }

    void LateUpdate()
    {
        if (playerPlane == null)
            return; 

        float acceleration = thrustScript.acceleration;

        Vector3 desiredPosition = playerPlane.position + playerPlane.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerPlane.rotation, smoothSpeed * Time.deltaTime);
    }
}
