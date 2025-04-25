
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public DefenseHealth defenseHealth;
    public float restartWaitSeconds = 3f;

    void Start()
    {
        SoundManager.Instance.PlayMusicSound(); 
    }

    void Update()
    {
        // Defense is destroyed if null 
        if (defenseHealth == null)
        {
            RestartGame();
        }

        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount <= 0)
        {
            RestartGame(); 
        }

        int playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        if (playerCount != 1)
        {
            RestartGame(); 
        }

    }

    void RestartGame()
    {
        // Give time between end of game and restart 
        StartCoroutine(WaitAndRestart(restartWaitSeconds));
    }

    IEnumerator WaitAndRestart(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
