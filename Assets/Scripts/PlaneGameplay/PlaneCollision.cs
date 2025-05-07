using UnityEngine;

// Behavior of the plane hitting an obsticale 
public class NewMonoBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        EventManager.Notify<GameEvent.PlaneCrash>(); 
        Destroy(gameObject);
    }
}
