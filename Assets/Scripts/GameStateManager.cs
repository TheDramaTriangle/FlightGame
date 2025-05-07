
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public DefenseHealth defenseHealth;
    public float restartWaitSeconds = 3f;

    void OnEnable()
    {
        EventManager.Subscribe<GameEvent.PlaneCrash>(RestartGame);
        EventManager.Subscribe<GameEvent.DefenseDestroyed>(RestartGame);
        EventManager.Subscribe<GameEvent.AllEnemiesDead>(RestartGame);
    }

    void OnDisable()
    {
        EventManager.Unsubscribe<GameEvent.PlaneCrash>(RestartGame);
        EventManager.Unsubscribe<GameEvent.DefenseDestroyed>(RestartGame);
        EventManager.Unsubscribe<GameEvent.AllEnemiesDead>(RestartGame);
    }

    void Start()
    {
        EventManager.Notify<GameEvent.GameStart>(); 
    }

    private void RestartGame()
    {
        // Give time between end of game and restart 
        StartCoroutine(WaitAndRestart(restartWaitSeconds));
    }

    private IEnumerator WaitAndRestart(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
