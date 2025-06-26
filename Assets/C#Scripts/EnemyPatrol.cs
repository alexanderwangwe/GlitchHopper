using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform target;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        // Move toward the target point
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Switch direction when close enough
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
