using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    public AudioSource gameplayMusic;
    public AudioSource pauseMusic;

    void Start()
    {
        pauseMenu.SetActive(false);
        pauseMusic.Stop(); // make sure pause music isn't playing
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        gameplayMusic.Pause();
        pauseMusic.Play();

        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        pauseMusic.Stop();
        gameplayMusic.UnPause();

        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;

        pauseMusic.Stop();
        gameplayMusic.Stop();

        SceneManager.LoadScene("Menu");
    }
}
