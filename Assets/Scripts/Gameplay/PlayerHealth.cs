using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public GameOver gameOver;

    [Header("Invincibility")]
    public float invincibilityDuration = 1f;
    private bool isInvincible = false;

    [Header("Flash")]
    public float flashInterval = 0.1f;
    private Renderer[] cachedRenderers;
    
    // [Header("Audio")]
    // public AudioClip damageSound;
    // public AudioClip deathSound;
    // private AudioSource audioSource;

    private void Awake()
    {
        currentHealth = maxHealth;
        cachedRenderers = GetComponentsInChildren<Renderer>(true);
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible || damage <= 0)
        {
            return;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        StartCoroutine(InvincibilityFrames());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        if (cachedRenderers != null && cachedRenderers.Length > 0)
        {
            float elapsed = 0f;
            bool visible = true;

            while (elapsed < invincibilityDuration)
            {
                visible = !visible;
                SetRenderersVisible(visible);
                yield return new WaitForSeconds(flashInterval);
                elapsed += flashInterval;
            }

            SetRenderersVisible(true);
        }
        else
        {
            yield return new WaitForSeconds(invincibilityDuration);
        }
        isInvincible = false;
    }

    private void SetRenderersVisible(bool visible)
    {
        for (int i = 0; i < cachedRenderers.Length; i++)
        {
            if (cachedRenderers[i] != null)
            {
                cachedRenderers[i].enabled = visible;
            }
        }
    }

    private void Die()
    {
        if (gameOver != null)
        {
            gameOver.TriggerGameOver();
        }
        else
        {
            Debug.LogWarning("GameOver script not assigned to PlayerHealth.");
            // Fallback: just reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
