using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject mainMenuUI; // Play, Settings, Quit -valikko

    // Play-nappi
    public void PlayGame()
    {
        SceneManager.LoadScene("Test");
        // Vaihda "GameScene" omaksi pelisi skenen nimeksi
    }

    public void OpenSettingMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
        // Vaihda "GameScene" omaksi pelisi skenen nimeksi
    }

    // Settings-nappi
    public void OpenSettings()
    {
        mainMenuUI.SetActive(false);
        settingsMenu.SetActive(true);
    }

    // Back-nappi asetuksissa
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    // Quit-nappi
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game (Toimii vain buildissa)");
    }
}
