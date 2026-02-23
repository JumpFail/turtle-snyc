using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void Quit()
    {
        // This only works in a built application
        Application.Quit();

        // For editor testing purposes
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
