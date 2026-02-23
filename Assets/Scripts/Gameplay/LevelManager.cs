using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject levelCompleteUI;

    public void ShowLevelComplete()
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f; // optional: pause game
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("SceneToLoad", nextSceneIndex);
        SceneManager.LoadScene("LoadingScreen");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
