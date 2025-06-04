using UnityEngine;

public class DefenseHealth : MonoBehaviour
{
    public const int health = 500; //temporary change for testing (original: 500) 
    private int currentHealth; 
    public string defenseName; 

    void Start()
    {
        currentHealth = health; 
        EventManager.Notify(new GameEvent.DefenseSpawned(defenseName));
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; 
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            EventManager.Notify<GameEvent.DefenseDestroyed>(); 
        }
        else
        {
            float healthPercentage = (float)currentHealth / (float)health; 
            EventManager.Notify(new GameEvent.DefenseDamaged(healthPercentage, defenseName));
        }
    }
}
