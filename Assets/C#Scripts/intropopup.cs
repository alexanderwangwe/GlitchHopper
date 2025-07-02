using UnityEngine;

public class IntroPopup : MonoBehaviour
{
    public GameObject instructionPanel;

    void Start()
    {
        // Show instructions and pause the game
        instructionPanel.SetActive(true);
        Time.timeScale = 0f; // Freeze everything
    }

    void Update()
    {
        if (instructionPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            // Hide instructions and unpause the game
            instructionPanel.SetActive(false);
            Time.timeScale = 1f; // Resume game
        }
    }
}
