using UnityEngine;

public class FragmentControl : MonoBehaviour
{
    [SerializeField] private int rotateSpeed = 2;
    [SerializeField] private AudioSource fragmentCollect;
    [SerializeField] private int fragmentScore = 1;

    private bool isCollected = false;

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (isCollected || !other.CompareTag("Player")) return;

        isCollected = true;

        FragmentScore.totalFragments += fragmentScore;

        if (fragmentCollect != null)
        {
            fragmentCollect.Play();
            Destroy(gameObject, fragmentCollect.clip.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
