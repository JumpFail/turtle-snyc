using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    [Header("UI References")]
    public Slider loadingSlider;      // Assign in Inspector
    public TMP_Text loadingText;          // Optional: assign a Text UI element (for "Loading...")
    
    [Header("Settings")]
    public float minimumLoadTime = 2f; // Minimum time in seconds the loading screen stays visible

    private void Start()
    {
        int sceneToLoad = PlayerPrefs.GetInt("SceneToLoad", 1);
        StartCoroutine(LoadAsync(sceneToLoad));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float startTime = Time.time;
        int dotCount = 0;

        while (!operation.isDone)
        {
            // Calculate loading progress (0 to 1)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = Mathf.Lerp(loadingSlider.value, progress, Time.deltaTime * 1f);

            // Animate dots every ~0.5 seconds
            if (loadingText)
            {
                dotCount = (int)(Time.time * 2 % 4); // 0–3 dots
                loadingText.text = "Loading" + new string('.', dotCount);
            }

            // When loading finishes (reaches 90%)
            if (operation.progress >= 0.9f)
            {
                // Wait until the minimum load time has passed
                if (Time.time - startTime >= minimumLoadTime)
                {
                    loadingSlider.value = 1f; // Fill bar
                    operation.allowSceneActivation = true; // Activate scene
                }
            }

            yield return null;
        }
    }
}

// main loading system