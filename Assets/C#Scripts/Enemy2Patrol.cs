using UnityEngine;

public class Enemy2Patrol : MonoBehaviour
{
    public Transform patrolPointC;
    public Transform patrolPointD;
    public float speed = 2f;

    private Transform target;

    void Start()
    {
        target = patrolPointD;
    }

    void Update()
    {
        if (patrolPointC == null || patrolPointD == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == patrolPointC) ? patrolPointD : patrolPointC;
        }
    }
}
