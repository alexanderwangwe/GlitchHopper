using UnityEngine;

public class FragmentScore : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text scoreBox; // UI text element
    [SerializeField] private GameObject portal;       // Portal GameObject
    public static int totalFragments = 0;
    private int targetFragments = 5;

    private bool portalActivated = false;

    void Start()
    {
        if (scoreBox == null)
        {
            Debug.LogError("Score Box is not assigned in the FragmentScore script.");
        }
        if (portal == null)
        {
            Debug.LogError("Portal GameObject is not assigned in the FragmentScore script.");
        }

        if (portal != null)
        {
            portal.SetActive(false); // Hide portal at game start
        }
    }

    void Update()
    {
        if (scoreBox != null)
        {
            scoreBox.text = "Fragments: " + totalFragments + "/" + targetFragments;
        }

        // Activate portal when enough fragments collected
        if (!portalActivated && totalFragments >= targetFragments)
        {
            portalActivated = true;

            if (portal != null)
            {
                portal.SetActive(true);
            }
        }
    }
}
