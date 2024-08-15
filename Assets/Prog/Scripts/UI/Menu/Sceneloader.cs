using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        // Finde die AudioManager-Instanz in der Szene
        audioManager = AudioManager.instance;

        if (audioManager != null)
        {
            // Überprüfe, welche Szene geladen wurde
            Scene currentScene = SceneManager.GetActiveScene();

            // Ändere die Musik abhängig von der geladenen Szene
            switch (currentScene.name)
            {
            //    case "Titlescreen":
            //        audioManager.ChangeMusic(audioManager.UI);
            //        break;
                case "MainUI":
                    audioManager.ChangeMusic(audioManager.UI);
                    break;
                case "DungeonRookie":
                    audioManager.ChangeMusic(audioManager.Game);
                    break;
                case "DungeonEasy":
                    audioManager.ChangeMusic(audioManager.Game);
                    break;
                case "DungeonNormal":
                    audioManager.ChangeMusic(audioManager.Game);
                    break;
                case "DungeonHard":
                    audioManager.ChangeMusic(audioManager.Game);
                    break;
                case "DungeonInsane":
                    audioManager.ChangeMusic(audioManager.Game);
                    break;
                case "YouWon":
                    audioManager.ChangeMusic(audioManager.UI);
                    break;
                case "Scoreboard":
                    audioManager.ChangeMusic(audioManager.UI);
                    break;
                default:
                    Debug.LogWarning("Scene music not specified for scene: " + currentScene.name);
                    break;
            }
        }
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadPreviousScene()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousSceneIndex < 0)
        {
            previousSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        }
        SceneManager.LoadScene(previousSceneIndex);
    }

    public void ReloadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
