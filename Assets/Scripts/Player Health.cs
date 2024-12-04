using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 2; // Starting health
    public float fallThreshold = -10f; // Y position threshold to detect falling off the map

    void Update()
    {
        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            Die();
        }
    }

    // Call this function when the player is hit by an enemy
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    // Handle player death
    private void Die()
    {
        Debug.Log("Player Died!");
        Time.timeScale = 0; // Freeze the game
    }

    // Detect collision with an enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); // Lose 1 health when colliding with an enemy
        }
    }
}
