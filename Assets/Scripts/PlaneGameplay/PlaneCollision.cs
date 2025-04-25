using UnityEngine;

// Behavior of the plane hitting an obsticale 
public class NewMonoBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        SoundManager.Instance.PlayExplosionSound(); 
        Destroy(gameObject);
    }
}
