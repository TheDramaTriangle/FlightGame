using System;
using TMPro;
using UnityEngine;

public class DisplayUpdater : MonoBehaviour
{
    public DefenseHealth defenseHealth; 
    public TextMeshProUGUI ui;

    void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        string defenseText = defenseHealth != null ? "Defense Health: " + defenseHealth.health.ToString() : "Defense Destroyed!"; 
        string enemyText = enemyCount > 0 ? "Enemies Remaining: " + enemyCount.ToString() : "All Enemies Defeated!";
        ui.text = defenseText + "\n" + enemyText; 
    }
}
