using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float stopDistance = 1f; // How far from the platform to stop

    private Transform target;
    private float fixedY;

    void Start()
    {
        transform.position = pointA.position;
        target = pointB;
        fixedY = pointA.position.y;
    }

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 targetPosition = target.position - direction * stopDistance;
        targetPosition.y = fixedY;

        // Move toward offset target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Switch if close enough
        if (Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }

    void OnDrawGizmos()
{
    if (pointA != null && pointB != null)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}

}
