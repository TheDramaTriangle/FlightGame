using UnityEngine;
using System.Collections.Generic;


public class DefenseUIManager : MonoBehaviour 
{
    public GameObject defenseUIPrefab;

    private Dictionary<string, DefenseHealthUpdater> uiEntries = new();

    void Awake()
    {
        EventManager.Subscribe<GameEvent.DefenseSpawned>(RegisterDefense);
        EventManager.Subscribe<GameEvent.DefenseDamaged>(UpdateDefenseHealth);
    }

    void OnDisable()
    {
        EventManager.Unsubscribe<GameEvent.DefenseSpawned>(RegisterDefense); 
        EventManager.Unsubscribe<GameEvent.DefenseDamaged>(UpdateDefenseHealth); 
    }


    public void RegisterDefense(GameEvent.DefenseSpawned defense) 
    {
        var ui = Instantiate(defenseUIPrefab, transform);
        var defenseHealth = ui.GetComponent<DefenseHealthUpdater>();
        defenseHealth.UpdateHealth(defense.Name, 1f);
        uiEntries[defense.Name] = defenseHealth;
    }

    public void UpdateDefenseHealth(GameEvent.DefenseDamaged defense) 
    {
        uiEntries[defense.Name].UpdateHealth(defense.Name, defense.HealthPercentage);
    }
}

