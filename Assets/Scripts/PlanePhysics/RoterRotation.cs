using UnityEngine;

public class TurbineRotation : MonoBehaviour
{
    public float rotationSpeed = 300f; 
    public Transform roter; 

    void Update()
    {
        roter.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
