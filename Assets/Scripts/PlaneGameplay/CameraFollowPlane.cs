using UnityEngine;

public class CameraFollowPlane : MonoBehaviour
/*
    Set the camera to follow the plane from a third person view 
*/
{
    public Transform playerPlane;  
    public Vector3 offset = new(0, 1, -3); 
    public float smoothSpeed = 3f; 

    void LateUpdate()
    {
        if (playerPlane == null)
            return; 

        Vector3 desiredPosition = playerPlane.position + playerPlane.rotation * offset; 
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerPlane.rotation, smoothSpeed * Time.deltaTime);
    }
}
