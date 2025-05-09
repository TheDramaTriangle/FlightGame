using Unity.VisualScripting;
using UnityEngine;

public class DefenseHealth : MonoBehaviour
{
    public int health = 500; 

    void Start()
    {
        EventManager.Notify(new GameEvent.DefenseSpawned(health));
    }


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; 
        if (health <= 0)
        {
            Destroy(gameObject);
            EventManager.Notify<GameEvent.DefenseDestroyed>(); 
        }
        else
        {
            EventManager.Notify(new GameEvent.DefenseDamaged(health));
        }
    }
}
