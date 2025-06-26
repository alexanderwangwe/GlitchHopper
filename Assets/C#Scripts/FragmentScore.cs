using UnityEngine;

public class FragmentScore : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text scoreBox; // directly reference TMP_Text
    [SerializeField] private GameObject portal;
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

        portal.SetActive(false); // Ensure portal is initially inactive
    }

    void Update()
    {
        if (scoreBox != null)
        {
            scoreBox.text = "Fragments: " + totalFragments + "/" + targetFragments;
        }

        if (!portalActivated && totalFragments >= targetFragments)
        {
            portalActivated = true;
            portal.SetActive(true);
        }
    }
}
