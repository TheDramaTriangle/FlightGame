using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Transform shootPosition; 
    public GameObject crossHair;
    public LayerMask ignoreLayers;
    public float smoothSpeed = 20f; 


    void Update()
    {
        if (shootPosition == null)
            return; 


        // To ignore bullets
        int mask = ~ignoreLayers;

        Ray ray = new Ray(shootPosition.position, shootPosition.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, mask))
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(hit.point);
            crossHair.transform.position = Vector3.Lerp(crossHair.transform.position, screenPos, Time.deltaTime * smoothSpeed);
        }
    }
}
