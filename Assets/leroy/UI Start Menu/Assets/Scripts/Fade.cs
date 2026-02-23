using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public CanvasGroup mainMenu;
    public CanvasGroup optionsMenu;
    public float fadeDuration = 0.5f;

    void Start()
    {
        // Ensure Main Menu is active and Options Menu is hidden initially
        mainMenu.alpha = 1;
        mainMenu.interactable = true;
        mainMenu.blocksRaycasts = true;

        optionsMenu.alpha = 0;
        optionsMenu.interactable = false;
        optionsMenu.blocksRaycasts = false;
    }

    public void OnOptionsButtonClicked()
    {
        StartCoroutine(FadeOut(mainMenu));
        StartCoroutine(FadeIn(optionsMenu));
    }

    public void OnBackButtonClicked()
    {
        StartCoroutine(FadeOut(optionsMenu));
        StartCoroutine(FadeIn(mainMenu));
    }

    IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    IEnumerator FadeOut(CanvasGroup canvasGroup)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}

// currently unused