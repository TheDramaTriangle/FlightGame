using UnityEngine;

// Behavior of the plane hitting an obsticale 
public class NewMonoBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
