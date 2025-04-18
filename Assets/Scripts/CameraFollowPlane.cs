using UnityEngine;

public class CameraFollowPlane : MonoBehaviour
{
    public Transform playerPlane;  
    public Vector3 offset = new(0, 1, -3); 
    public float smoothSpeed = 10f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LateUpdate()
    {
        Vector3 desiredPosition = playerPlane.position + offset; 
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.LookAt(playerPlane);
    }
}
