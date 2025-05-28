using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI enemyText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HealthText;

    void OnEnable()
    {
        EventManager.Subscribe<GameEvent.EnemyDied>(DisplayEnemyNum);
        EventManager.Subscribe<GameEvent.EnemySpawned>(DisplayEnemyNum);
        EventManager.Subscribe<GameEvent.AllEnemiesDead>(DisplayEnemiesDead);

        EventManager.Subscribe<GameEvent.ScoreChanged>(DisplayScore);
        EventManager.Subscribe<GameEvent.PlayerDamaged>(DisplayHealth);
    }
    void OnDisable()
    {
        EventManager.Unsubscribe<GameEvent.EnemyDied>(DisplayEnemyNum);
        EventManager.Unsubscribe<GameEvent.EnemySpawned>(DisplayEnemyNum);
        EventManager.Unsubscribe<GameEvent.AllEnemiesDead>(DisplayEnemiesDead);

        EventManager.Unsubscribe<GameEvent.ScoreChanged>(DisplayScore);
        EventManager.Unsubscribe<GameEvent.PlayerDamaged>(DisplayHealth);
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

    void DisplayScore(GameEvent.ScoreChanged ev)
    {
        ScoreText.text = "Score: " + ev.NewScore;
    }

    void DisplayHealth(GameEvent.PlayerDamaged ev)
    {
        return;
        // HealthText.text = "Health: " + ev.Health;
    }
}
