using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Sources ----------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Mixer ----------")]
    [SerializeField] AudioMixer AudioMixer;


    [Header("---------- BGM Music ----------")]
    public AudioClip UI;
    public AudioClip Game;
    public AudioClip Win;
    public AudioClip Loose;


    //  [Header("---------- SFX Clips ----------")]
    //  public AudioClip Jump;
    //  public AudioClip Steps;
    //  public AudioClip Menu;
    //  public AudioClip Collect;

    // Singleton instance
    public static AudioManager instance;


    private void Awake()
    {
        // Ensures only one instance of AudioManager exists throughout the game.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Starts playing music when the game starts.
        PlayMusic(UI);
    }

    // Plays a sound effect once.
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // Plays the collect sound effect.
    //  public void PlayCollectSound()
    //  {
    //      sfxSource.PlayOneShot(Collect);
    //  }

    // Plays music.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    // Changes the current playing music to a new clip.
    public void ChangeMusic(AudioClip newClip)
    {
        MusicSource.Stop();
        MusicSource.clip = newClip;
        MusicSource.Play();
    }

    // Changes the output audio mixer group of a specific sound
    public void ChangeSoundMixerGroup(string soundName, string mixerGroupName)
    {
        GameObject soundObject = GameObject.Find(soundName);
        if (soundObject != null)
        {
            AudioSource audioSource = soundObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.outputAudioMixerGroup = AudioMixer.FindMatchingGroups(mixerGroupName)[0];
            }
            else
            {
                Debug.LogError("AudioSource not found for sound: " + soundName);
            }
        }
        else
        {
            Debug.LogError("Sound not found: " + soundName);
        }
    }
}
