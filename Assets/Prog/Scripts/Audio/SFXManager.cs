using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip menuSound;
    [SerializeField] private AudioClip stepsSound;

    [SerializeField] private AudioMixerGroup SFXMixerGroup;  // Reference to the SFX mixer group.

    private bool isActive = true; // Flag to control whether sound effects are active.

    // Helper method to play a sound clip through the SFX mixer group.
    private void PlaySound(AudioClip clip)
    {
        if (clip != null && isActive)
        {
            // Create an AudioSource at the point of the collision.
            AudioSource tempAudioSource = new GameObject("TempAudio").AddComponent<AudioSource>();
            tempAudioSource.clip = clip;
            tempAudioSource.outputAudioMixerGroup = SFXMixerGroup; // Assign the SFX mixer group.
            tempAudioSource.transform.position = transform.position;
            tempAudioSource.Play();

            // Destroy the temporary AudioSource after the clip has finished playing.
            Destroy(tempAudioSource.gameObject, clip.length);
        }
    }

    // Triggered when the Player enters a trigger collider.
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that entered the collider is the player.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Play the hit sound through the SFX mixer group.
            PlaySound(HitSound);
        }
    }

    // Play the jump sound effect.
    public void PlayJumpSound()
    {
        // Play the jump sound through the SFX mixer group.
        PlaySound(jumpSound);
    }

    // Play the menu sound effect.
    public void PlayMenuSound()
    {
        // Play the menu sound through the SFX mixer group.
        PlaySound(menuSound);
    }

    // Play the steps sound effect.
    public void PlayStepsSound()
    {
        // Play the steps sound through the SFX mixer group.
        PlaySound(stepsSound);
    }

    // Toggle the active state of sound effects.
    public void ToggleActiveState()
    {
        // Invert the value of isActive.
        isActive = !isActive;
    }
}
