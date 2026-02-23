using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject quitConfirmationPanel;

    // Load Scene (go to loading screen first)
    public void Play()
    {
        // Set the target to Level1 (index 2 in this example)
        PlayerPrefs.SetInt("SceneToLoad", 2);
        SceneManager.LoadScene("LoadingScreen");
    }

    public void ShowQuitConfirmation()
    {
        quitConfirmationPanel.SetActive(true);
    }

    public void HideQuitConfirmation()
    {
        quitConfirmationPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Debug.Log("Player has quit the game.");
    }
}
