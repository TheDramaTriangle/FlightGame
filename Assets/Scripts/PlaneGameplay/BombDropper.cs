
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombPoint; 
    public float bombCooldown = 5f; 
    private float lastBombTime = 0f; 

    void Start()
    {
        if (!UnlockedUpgrades.isBombUnlocked)
        {
            this.enabled = false; 
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R)) 
        {
            if (Time.time - lastBombTime >= bombCooldown)
            {
                DropBomb();
                lastBombTime = Time.time; 
            }
        }
    }

    void DropBomb()
    {
        Instantiate(bombPrefab, bombPoint.position, bombPoint.rotation);
    }
}


