using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Play-nappi
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Test");
    }

    // Settings-nappi (avaa Settings-scenen ja muistaa mistä tultiin)
    public void OpenSettings()
    {
        SceneLoader.LoadSettings();
    }

    // Quit-nappi
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game (toimii vain buildissa)");
    }
}

