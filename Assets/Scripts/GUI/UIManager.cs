using System;
using TMPro;
using UnityEngine;

public class UIManager: MonoBehaviour
{
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI enemyText;
    public TextMeshProUGUI ScoreText;

    void OnEnable()
    {
        EventManager.Subscribe<GameEvent.EnemyDied>(DisplayEnemyNum);
        EventManager.Subscribe<GameEvent.EnemySpawned>(DisplayEnemyNum);
        EventManager.Subscribe<GameEvent.AllEnemiesDead>(DisplayEnemiesDead); 

        EventManager.Subscribe<GameEvent.DefenseSpawned>(DisplayDefenseHealth);
        EventManager.Subscribe<GameEvent.DefenseDamaged>(DisplayDefenseHealth);
        EventManager.Subscribe<GameEvent.DefenseDestroyed>(DisplayDefenseDestroyed); 
        EventManager.Subscribe<GameEvent.ScoreChanged>(DisplayScore); 
    }
    void OnDisable()
    {
        EventManager.Unsubscribe<GameEvent.EnemyDied>(DisplayEnemyNum);
        EventManager.Unsubscribe<GameEvent.EnemySpawned>(DisplayEnemyNum);
        EventManager.Unsubscribe<GameEvent.AllEnemiesDead>(DisplayEnemiesDead); 

        EventManager.Unsubscribe<GameEvent.DefenseDamaged>(DisplayDefenseHealth);
        EventManager.Unsubscribe<GameEvent.DefenseDestroyed>(DisplayDefenseDestroyed);
        EventManager.Unsubscribe<GameEvent.ScoreChanged>(DisplayScore); 
    }

    void DisplayEnemyNum(GameEvent.EnemyDied ev)
    {
        enemyText.text = "Enemies Remaining: " + ev.EnemiesRemaining.ToString();
    }
    void DisplayEnemyNum(GameEvent.EnemySpawned ev)
    {
        enemyText.text = "Enemies Remaining: " + ev.EnemiesRemaining.ToString();
    }

    void DisplayEnemiesDead()
    {
        enemyText.text = "All Enemies defeated!";
    }

    void DisplayDefenseHealth(GameEvent.DefenseDamaged ev)
    {
        defenseText.text = "Defense Health: " + ev.HealthRemaining.ToString(); 
    }
    void DisplayDefenseHealth(GameEvent.DefenseSpawned ev)
    {
        defenseText.text = "Defense Health: " + ev.Health.ToString(); 
    }

    void DisplayDefenseDestroyed()
    {
        defenseText.text = "Defense destroyed!";
    }

    void DisplayScore(GameEvent.ScoreChanged ev)
    {
        ScoreText.text = "Score: " + ev.NewScore;
    }
}
