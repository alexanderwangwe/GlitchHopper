using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform checkpoint; // Assign in Inspector
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Disable controller before teleporting to avoid collision bugs
        controller.enabled = false;
        transform.position = checkpoint.position;
        controller.enabled = true;
    }
}
