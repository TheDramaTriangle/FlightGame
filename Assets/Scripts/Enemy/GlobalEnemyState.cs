using GameEvent;
using UnityEngine;

public class GlobalEnemyState : MonoBehaviour
{
    private static int enemiesRemaining = 0; 

    void Start()
    {
        enemiesRemaining++; 
        EventManager.Notify(new GameEvent.EnemySpawned(enemiesRemaining));
    }

    void OnDisable()
    {
        enemiesRemaining--; 
        if (enemiesRemaining != 0)
        {
            EventManager.Notify(new GameEvent.EnemyDied(enemiesRemaining));
        }
        else
        {
            EventManager.Notify<GameEvent.AllEnemiesDead>();
        }
    }
}
