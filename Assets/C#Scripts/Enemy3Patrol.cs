using UnityEngine;

public class Enemy3Patrol : MonoBehaviour
{
    public Transform patrolPointE;
    public Transform patrolPointF;
    public float speed = 2f;

    private Transform target;

    void Start()
    {
        target = patrolPointF;
    }

    void Update()
    {
        if (patrolPointE == null || patrolPointF == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == patrolPointE) ? patrolPointF : patrolPointE;
        }
    }
}
