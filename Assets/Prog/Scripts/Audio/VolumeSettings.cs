using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    // Referenzen auf den AudioMixer und die Schieberegler f�r die Lautst�rkeregelung
    [SerializeField] private AudioMixer MainMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        // �berpr�fen, ob Lautst�rkeeinstellungen gespeichert sind
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            // Wenn gespeichert, Lautst�rke laden
            LoadVolume();
        }
        else
        {
            // Ansonsten Standardwerte setzen
            SetMasterVolume();
            SetBGMVolume();
            SetSFXVolume();
        }
    }

    // Methode zum Setzen der Masterlautst�rke
    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        MainMixer.SetFloat("Master", Mathf.Log10(volume) * 20); // Lautst�rke im Mixer setzen
        PlayerPrefs.SetFloat("masterVolume", volume); // Lautst�rke speichern
    }

    // Methode zum Setzen der Musiklautst�rke
    public void SetBGMVolume()
    {
        float volume = BGMSlider.value;
        MainMixer.SetFloat("BGM", Mathf.Log10(volume) * 20); // Lautst�rke im Mixer setzen
        PlayerPrefs.SetFloat("BGMVolume", volume); // Lautst�rke speichern
    }

    // Methode zum Setzen der SFX-Lautst�rke
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        MainMixer.SetFloat("SFX", Mathf.Log10(volume) * 20); // Lautst�rke im Mixer setzen
        PlayerPrefs.SetFloat("SFXVolume", volume); // Lautst�rke speichern
    }

    // Methode zum Laden der gespeicherten Lautst�rkeeinstellungen
    private void LoadVolume()
    {
        // Gespeicherte Lautst�rkewerte laden
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        // Lautst�rke entsprechend der geladenen Werte setzen
        SetMasterVolume();
        SetBGMVolume();
        SetSFXVolume();
    }
}