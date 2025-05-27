using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen Instance { get; private set; }
    public TMP_Text ScoreText;

    private void Awake()
    {
        Instance = this;
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        ScoreText.text = "Score: " + score.ToString();
    }
}
