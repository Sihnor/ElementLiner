using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject mainMenuContainer;

    [SerializeField] GameObject mainMainMenu;
    [SerializeField] GameObject mainSettings;
    [SerializeField] GameObject mainCredits;
    [SerializeField] GameObject mainDifficulty;

    void Start()
    {
        // Stelle sicher, dass nur das Hauptmenü aktiviert ist, wenn das Spiel startet
        ActivateMainMainMenu();
    }

    public void ActivateMainMainMenu()
    {
        mainMainMenu.SetActive(true);
        mainSettings.SetActive(false);
        mainCredits.SetActive(false);
        mainDifficulty.SetActive(false);
    }

    public void ActivateMainSettings()
    {
        mainSettings.SetActive(true);
        mainMainMenu.SetActive(false);
        mainCredits.SetActive(false);
        mainDifficulty.SetActive(false);
    }

    public void ActivateMainCredits()
    {
        mainCredits.SetActive(true);
        mainMainMenu.SetActive(false);
        mainSettings.SetActive(false);
        mainDifficulty.SetActive(false);
    }
    
    public void ActivateMainDifficulty()
    {
        mainDifficulty.SetActive(true);
        mainMainMenu.SetActive(false);
        mainSettings.SetActive(false);
        mainCredits.SetActive(false);
    }
}
