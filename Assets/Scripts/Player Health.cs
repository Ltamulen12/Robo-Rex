using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Image[] hearts; // Array to hold heart images in the UI
    public int maxHealth = 3; // Maximum health, same as the number of hearts
    public int health; // Current health
    public SpriteRenderer playerSprite; // Reference to the player's sprite renderer
    public GameObject gameOverPanel; // Reference to the Game Over UI panel
    public float fallThreshold = -10f; // Y position threshold to detect falling off the map

    void Start()
    {
        // Initialize the game state
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false); // Hide the Game Over panel at the start
        health = maxHealth; // Set the player's health to the maximum
        UpdateHearts(); // Update the heart UI
    }

    void Update()
    {
        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            Die();
        }
    }

    // Detect collision with an enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); // Lose 1 health when colliding with an enemy
        }
    }

    // Function to handle damage when the player is hit
    public void TakeDamage(int damage)
    {
        // Reduce health by the specified damage amount
        health -= damage;

        // Update the heart display
        UpdateHearts();

        // Check if the player's health has dropped to 0 or below
        if (health <= 0)
        {
            Die();
        }
    }

    // Update the heart UI based on the current health
    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Enable hearts for remaining health, disable for lost health
            hearts[i].enabled = i < health;
        }
    }

    // Handle player death
    private void Die()
    {
        Debug.Log("Player Died!");
        gameOverPanel.SetActive(true); // Show the Game Over panel
        Time.timeScale = 0; // Pause the game
    }

    // Restart the game when the Retry button is clicked
    public void RetryGame()
    {
        Debug.Log("Retrying game...");
        Time.timeScale = 1; // Ensure the game resumes
        health = maxHealth; // Restore the player's health to full
        UpdateHearts(); // Reset the heart UI
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
