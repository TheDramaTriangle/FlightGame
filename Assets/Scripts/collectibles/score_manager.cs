using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int CurrentScore = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // optional if you want it to persist
    }

    public void AddScore(int amount)
    {
        CurrentScore += amount;
        EventManager.Notify(new GameEvent.ScoreChanged(CurrentScore));
    }

    public int GetScore()
    {
        return CurrentScore;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }
}
