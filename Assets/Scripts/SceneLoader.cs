using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static string previousScene;

    public static void LoadSettings()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("SettingsMenu");
    }

    public static void LoadPreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }
}
