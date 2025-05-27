using UnityEngine;

// Behavior of the plane hitting an obsticale 
public class PlaneCollision: MonoBehaviour
{
    public GameObject explosionEffect; 
    void OnCollisionEnter(Collision collision)
    {
        EventManager.Notify<GameEvent.PlaneCrash>();
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
