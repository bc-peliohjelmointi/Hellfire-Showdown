using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public void Back()
    {
        if (string.IsNullOrEmpty(SceneLoader.previousScene))
            SceneManager.LoadScene("MainMenu");
        else
            SceneLoader.LoadPreviousScene();
    }
}

