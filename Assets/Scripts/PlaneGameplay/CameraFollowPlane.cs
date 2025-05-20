using UnityEngine;

public class CameraFollowPlane : MonoBehaviour
/*
    Set the camera to follow the plane from a third person view 
*/
{
    public Transform playerPlane;
    public Vector3 offset = new(0, 3, -3.5f);
    public float smoothSpeed = 3f;

    void Start()
    {
        if (playerPlane == null)
            return;

        Vector3 desiredPosition = playerPlane.position + playerPlane.rotation * offset;
        transform.SetPositionAndRotation(desiredPosition, playerPlane.rotation);
    }

    void LateUpdate()
    {
        if (playerPlane == null)
            return;

        Vector3 desiredPosition = playerPlane.position + playerPlane.rotation * offset;
        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, desiredPosition, smoothSpeed),
        Quaternion.Slerp(transform.rotation, playerPlane.rotation, smoothSpeed * Time.deltaTime));
    }
}
