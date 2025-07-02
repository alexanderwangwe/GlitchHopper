using UnityEngine;

public class MovingFloatingPlatform2 : MonoBehaviour
{
    public Transform pointC;
    public Transform pointD;
    public float speed = 2f;
    public float stopDistance = 1f; // How far from the platform to stop

    private Transform target;
    private float fixedY;

    void Start()
{
    if (pointC == null || pointD == null)
    {
        Debug.LogError("Missing pointC or pointD on " + gameObject.name);
        enabled = false;
        return;
    }

    transform.position = pointC.position;
    target = pointD;
    fixedY = pointC.position.y;
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
            target = (target == pointC) ? pointD : pointC;
        }
    }

    void OnDrawGizmos()
{
    if (pointC != null && pointD != null)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pointC.position, pointD.position);
    }
}

}
