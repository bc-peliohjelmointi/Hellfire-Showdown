using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SofiaScene"); // Vaihda oma peliscenesi nimi
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene"); // Vaihda oman asetusscenesi nimi
    }

    public void QuitGame()
    {
        Debug.Log("Quit game!");
        Application.Quit();
    }
}

