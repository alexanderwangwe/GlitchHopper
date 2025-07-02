using UnityEngine;
using UnityEngine.SceneManagement; // Optional, if loading scenes

public class PortalBehavior : MonoBehaviour
{
    public Transform teleportTarget; // Where the player will be moved to (optional)
    public string nextSceneName = ""; // Optional, if loading a new scene

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered portal!");

            if (teleportTarget != null)
            {
                other.transform.position = teleportTarget.position;
            }

            // Optional: load another scene
            // SceneManager.LoadScene(nextSceneName);
        }
    }
}
