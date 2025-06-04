
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float restartWaitSeconds = 3f;
    private int og_score; 

    void OnEnable()
    {
        EventManager.Subscribe<GameEvent.PlaneCrash>(GameOver);
        EventManager.Subscribe<GameEvent.DefenseDestroyed>(GameOver);
        EventManager.Subscribe<GameEvent.AllEnemiesDead>(GameWin);
        EventManager.Subscribe<GameEvent.ExitGame>(ExitGame);
    }

    void OnDisable()
    {
        EventManager.Unsubscribe<GameEvent.PlaneCrash>(GameOver);
        EventManager.Unsubscribe<GameEvent.DefenseDestroyed>(GameOver);
        EventManager.Unsubscribe<GameEvent.AllEnemiesDead>(GameWin);
        EventManager.Unsubscribe<GameEvent.ExitGame>(ExitGame);
    }

    void Start()
    {
        og_score = ScoreManager.currentScore; 
        EventManager.Notify<GameEvent.GameStart>();
    }

    private void GameOver()
    {
        ScoreManager.currentScore = og_score; 
        SwitchScene(SceneManager.GetActiveScene().name); 
    }

    private void ExitGame()
    {
        ScoreManager.currentScore = og_score; 
        SceneManager.LoadScene("TitleScene");
    }

    private void GameWin()
    {
        SwitchScene("TitleScene"); 
    }

    private void SwitchScene(string name)
    {
        // Give time between end of game and restart
        StartCoroutine(WaitAndLoadScene(restartWaitSeconds, name));
    }

    private IEnumerator WaitAndLoadScene(float seconds, string name)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(name);
    }



}
