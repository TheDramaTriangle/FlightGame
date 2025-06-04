using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static int currentScore = 999;

    void Start()
    {
        EventManager.Notify(new GameEvent.ScoreChanged(currentScore));
    }

    public static void AddScore(int amount)
    {
        currentScore += amount;
        EventManager.Notify(new GameEvent.ScoreChanged(currentScore));
    }

    public static void ResetScore()
    {
        currentScore = 0;
    }
}
