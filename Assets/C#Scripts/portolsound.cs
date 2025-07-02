using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSound : MonoBehaviour
{
    public AudioSource portalSound;
    public float delayBeforeNextLevel = 1f;

    private bool hasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            hasPlayed = true;
            portalSound.Play(); // Play the portal sound
            Invoke("LoadNextLevel", delayBeforeNextLevel); // Wait then load next scene
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

