using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUi;
    private float countdown;
    private static TimeUpdater instance;

    public static TimeUpdater Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
          //  DontDestroyOnLoad(this.gameObject); // Optionally keep this object between scene loads
        }

        InitializeCountdown(); // Initialize countdown based on the active scene
    }

    void InitializeCountdown()
    {
        // Get the active scene name
        string sceneName = SceneManager.GetActiveScene().name;

        // Set the countdown value based on the scene name
        switch (sceneName)
        {
            case "DungeonInsane":
                countdown = 1200f; // 20 Minutes for "DungeonInsane"
                break;
            case "DungeonHard":
                countdown = 800f; // 13,3 Minutes for "DungeonHard"
                break;
            case "DungeonNormal":
                countdown = 600f; // 10 Minutes for "DungeonNormal"
                break;
            case "DungeonEasy":
                countdown = 300f; // 5 Minutes for "DungeonEasy"
                break;
            case "DungeonRookie":
                countdown = 140f; // 2,3 Minutes for "DungeonRookie"
                break;
            default:
                countdown = 600f; // 10 Minutes Default - value, e.g., for other scenes
                break;
        }
    }

    void Update()
    {
        // Decrease the countdown value per second
        if (Time.timeScale > 0)
        {
            countdown -= Time.deltaTime;
        }

        // Ensure the countdown does not fall below 0
        if (countdown <= 0f)
        {
            // Load the scene with index 7 when the countdown reaches 0
            SceneManager.LoadScene(7);
        }
        else
        {
            // Set the text to the countdown value
            textMeshProUi.text = Mathf.Round(countdown).ToString();
            Debug.Log("Countdown updated: " + countdown);
        }
    }

    //   void OnTriggerEnter(Collider other)
    //   {
    //       if (other.CompareTag("Player"))
    //       {
    //           Debug.Log("Player collided with watch object.");
    //           // Increase time by 10 seconds
    //           AddTime(10);
    //           // Deactivate the collected object
    //           gameObject.SetActive(false);
    //       }
    //   }

    //  public void AddTime(int seconds)
    //  {
    //      // Increase time by the specified seconds
    //      countdown += seconds;
    //      Debug.Log("Time added: " + seconds + " seconds. New countdown: " + countdown);
    //  }
}
