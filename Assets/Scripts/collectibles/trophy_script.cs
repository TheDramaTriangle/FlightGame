using UnityEngine;

public class RotatingTrophy : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second

    void Update()
    {
        // Rotate around the Y axis (change Vector3.up to another axis if needed)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure your plane is tagged "Player"
        {
            ScoreManager.AddScore(10);
            Destroy(gameObject);

        }
    }
}

