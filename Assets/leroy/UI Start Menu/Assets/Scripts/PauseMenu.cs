using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu; // assign your Options panel here
    public bool isPaused;
    private bool inOptionsMenu = false;

    public AudioSource gameplayMusic;
    public AudioSource pauseMusic;

    void Start()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        pauseMusic.Stop(); // ensure pause music isn't playing
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inOptionsMenu)
            {
                CloseOptionsMenu();
            }
            else
            {
                if (isPaused)
                    ResumeGame();
                else
                    PauseGame();
            }
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
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;

        pauseMusic.Stop();
        gameplayMusic.UnPause();

        isPaused = false;
        inOptionsMenu = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;

        pauseMusic.Stop();
        gameplayMusic.Stop();

        SceneManager.LoadScene("Menu");
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
        inOptionsMenu = true;
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
        inOptionsMenu = false;
    }
}