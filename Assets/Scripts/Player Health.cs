using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 2; // Starting health
    public float fallThreshold = -10f; // Y position threshold to detect falling off the map
    private bool isGameOver = false; // Track whether the game is over

    void Update()
    {
        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            Die();
        }

        // Check if the Escape key is pressed after the player dies
        if (isGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
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
        isGameOver = true; // Set game over state
    }

    // Quit the game
    private void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Close the application
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