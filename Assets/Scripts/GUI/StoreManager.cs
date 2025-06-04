using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class StoreManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText; 
    public GameObject TitleUI; 
    public GameObject StoreUI; 
    public Button bombButton; 
    public Button slowButton; 


    public const int bombPrice = 100; 
    public const int slowTimePrice = 100; 

    void Start()
    {
        if (UnlockedUpgrades.isBombUnlocked)
            bombButton.interactable = false; 

        if (UnlockedUpgrades.isSlowTimeUnlocked)
            slowButton.interactable = false; 


        displayMoney(ScoreManager.currentScore);

        TMP_Text buttonText = bombButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = $"Buy Bomb Upgrade - {bombPrice}";

        buttonText = slowButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = $"Buy Slow Time Upgrade - {bombPrice}";
    }

    private void displayMoney(int money)
    {
        moneyText.text = $"Money: {money}"; 
    }

    public void BuyBomb()
    {
        if (ScoreManager.currentScore >= bombPrice)
        {
            ScoreManager.currentScore -= bombPrice; 
            UnlockedUpgrades.isBombUnlocked = true; 
            displayMoney(ScoreManager.currentScore);
            bombButton.interactable = false; 
        }
    }

    public void BuySlowTime()
    {
        if (ScoreManager.currentScore >= slowTimePrice)
        {
            ScoreManager.currentScore -= slowTimePrice; 
            UnlockedUpgrades.isSlowTimeUnlocked = true; 
            displayMoney(ScoreManager.currentScore);
            slowButton.interactable = false; 
        }
    }

    public void ExitStore()
    {
        StoreUI.SetActive(false);
        TitleUI.SetActive(true);
    }
}
