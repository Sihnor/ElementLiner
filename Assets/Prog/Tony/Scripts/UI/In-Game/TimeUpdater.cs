using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUi;
    private float countdown = 300f;
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
            // Reload the current scene
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        else
        {
            // Set the text to the countdown value
            textMeshProUi.text = Mathf.Round(countdown).ToString();
            Debug.Log("Countdown updated: " + countdown);
        }
    }
}
