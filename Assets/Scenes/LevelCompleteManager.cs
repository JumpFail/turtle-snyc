using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelCompleteManager : MonoBehaviour
{
    public GameObject levelCompleteUI;   // Drag LevelCompleteUI here
    public Image fadePanel;              // Drag FadePanel (black image)
    public float fadeDuration = 1f;

    public void TriggerLevelComplete()
    {
        StartCoroutine(FadeAndShowUI());
    }

    IEnumerator FadeAndShowUI()
    {
        // Fade to black
        float t = 0;
        Color c = fadePanel.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1, t / fadeDuration);
            fadePanel.color = c;
            yield return null;
        }

        // Show Level Complete UI
        levelCompleteUI.SetActive(true);
    }
}
