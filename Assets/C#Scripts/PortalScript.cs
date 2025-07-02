using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteUI; // UI canvas or panel
    [SerializeField] private string nextSceneName = "Level2";

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canTeleport) return;

        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f; // Pause the game
            if (levelCompleteUI != null)
            {
                levelCompleteUI.SetActive(true); // Show completion options
            }
            else
            {
                // If no UI, load next level directly
                Time.timeScale = 1f;
                SceneManager.LoadScene(nextSceneName);
            }

            canTeleport = false;
        }
    }
}
