
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float restartWaitSeconds = 3f;

    void OnEnable()
    {
        EventManager.Subscribe<GameEvent.PlaneCrash>(GameOver);
        EventManager.Subscribe<GameEvent.DefenseDestroyed>(RestartGame);
        EventManager.Subscribe<GameEvent.AllEnemiesDead>(RestartGame);
    }

    void OnDisable()
    {
        EventManager.Unsubscribe<GameEvent.PlaneCrash>(GameOver);
        EventManager.Unsubscribe<GameEvent.DefenseDestroyed>(RestartGame);
        EventManager.Unsubscribe<GameEvent.AllEnemiesDead>(RestartGame);
    }

    void Start()
    {
        EventManager.Notify<GameEvent.GameStart>();
    }

    private void GameOver()
    {
        GameOverScreen.Instance.Setup(ScoreManager.Instance.CurrentScore);
    }

    private void RestartGame()
    {
        // Give time between end of game and restart
        ScoreManager.Instance.ResetScore();
        StartCoroutine(WaitAndRestart(restartWaitSeconds));
    }

    private IEnumerator WaitAndRestart(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
