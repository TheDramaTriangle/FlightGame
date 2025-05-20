using GameEvent;
using UnityEngine;

public class EnemyCountUpdater: MonoBehaviour
{
    private static int enemiesRemaining = 0;

    void Start()
    {
        enemiesRemaining++;
        EventManager.Notify(new GameEvent.EnemySpawned(enemiesRemaining));
    }

    void OnDisable()
    {
        if (enemiesRemaining > 0)
        {
            enemiesRemaining--;
        }
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
