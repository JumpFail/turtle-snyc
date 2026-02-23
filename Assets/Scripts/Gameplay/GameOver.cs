using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    bool isGameOver;

    void Awake()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    // Call this from the player's health script when HP <= 0
    public void TriggerGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (gameOverPanel != null) gameOverPanel.SetActive(true);

        // Optionally stop/pause music manually here if needed
        Time.timeScale = 0f;
    }

    // Optional: keep trigger-based death zones
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isGameOver && other.CompareTag("Player"))
            TriggerGameOver();
    }

    // Helper to restart or return to menu (remember to set Time.timeScale = 1)
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}