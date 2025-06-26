using UnityEngine;

public class IntroPopup : MonoBehaviour
{
    public GameObject instructionPanel;

    void Start()
    {
        instructionPanel.SetActive(true); // Show instructions
    }

    void Update()
    {
        if (instructionPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            instructionPanel.SetActive(false); // Hide when space is pressed
        }
    }
}
