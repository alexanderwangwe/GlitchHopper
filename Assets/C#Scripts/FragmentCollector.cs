using UnityEngine;

public class FragmentCollector : MonoBehaviour
{
    public int fragmentsCollected = 0;
    public int totalFragments = 5;

    public GameObject levelCompleteUI; // <-- drag LevelCompleteUI here

    void Start()
    {
        // Hide the Level Complete pop-up when the game starts
        levelCompleteUI.SetActive(false);
    }

    public void CollectFragment()
    {
        fragmentsCollected++;

        // Check if we reached the goal
        if (fragmentsCollected >= totalFragments)
        {
            levelCompleteUI.SetActive(true); // Show the pop-up
        }
    }
}
