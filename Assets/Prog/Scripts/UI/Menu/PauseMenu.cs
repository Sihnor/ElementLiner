using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; // Das Canvas, das über das Hauptcanvas gelegt wird

    void Start()
    {
        // Setze das Overlay-Canvas auf inaktiv
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Ensure the game starts unpaused
    }

    void Update()
    {
        // Wenn die Escape-Taste gedrückt wird, wird das Spiel pausiert oder fortgesetzt
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            TogglePause();
        }
    }

    public void TogglePause()
    {
        bool isPaused = pauseMenu.activeSelf;
        Debug.Log("Current Pause State: " + isPaused);


        if (isPaused)
        {
            // Resuming the game
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Game Resumed");

        }
        else
        {
            // Pausing the game
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Game Paused");
        }
    }

    public void RestartGame()
    {
        // Lade die aktuelle Szene neu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // Ensure timeScale is reset when restarting the game
    }

    public void QuitGame()
    {
        // Beende das Spiel
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
