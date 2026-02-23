using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public static Loading Instance;

    private string sceneToLoad;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Call this to switch scenes using the loading screen.
    /// </summary>
    public void SwitchToScene(int sceneBuildIndex)
    {
        // Store the target scene index
        PlayerPrefs.SetInt("TargetSceneIndex", sceneBuildIndex);
        PlayerPrefs.Save();

        // Load the loading scene
        SceneManager.LoadScene("Loading");
    }

    /// <summary>
    /// Call this if you prefer to switch by name instead of build index.
    /// </summary>
    public void SwitchToScene(string sceneName)
    {
        PlayerPrefs.SetString("TargetSceneName", sceneName);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Loading");
    }
}
