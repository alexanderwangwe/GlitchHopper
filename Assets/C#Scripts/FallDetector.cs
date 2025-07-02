using UnityEngine;

using UnityEngine.SceneManagement;
public class FallDetector : MonoBehaviour
{
    public float fallThreshold = -10f; // If player goes below this, they "fall"
    public GameObject gameOverUI; // Drag your GameOverUI here

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Show the Game Over panel
            Time.timeScale = 0f; // Pause the game
        }
    }
    public void RestartLevel()
{
    Time.timeScale = 1f; // Unpause the game
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current level
}
}
