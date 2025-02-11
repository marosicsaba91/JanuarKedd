using UnityEngine;

enum MovementType { Frequency, Speed }

public class BackAndForth : MonoBehaviour
{
    [SerializeField] Vector3 p1, p2;

    [SerializeField] MovementType movementType;
    [SerializeField] float movement = 1;

    // [SerializeField] float speed = 1;
    //[SerializeField] float frequency;

    // [SerializeField] Transform t1, t2;

    Vector3 currentTarget;

    void Start()
    {
        transform.position = p1;
        currentTarget = p2;
    }

    void Update()
    {
        float speed = 0;
        if (movementType == MovementType.Frequency)
        {
            float movementTime = 1 / movement;
            float distance = Vector3.Distance(p1, p2);
            speed = distance / movementTime;
        }
        else if(movementType == MovementType.Speed)
        {
            speed = movement;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (transform.position == currentTarget)
        {
            currentTarget = currentTarget == p1 ? p2 : p1;
        }
    }

    void OnDrawGizmos()
    {
        /*
        if (t1 == null || t2 == null)
            return;

        Vector3 p1 = t1.position;
        Vector3 p2 = t2.position;
        */

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(p1, 0.25f);
        Gizmos.DrawWireSphere(p2, 0.25f);
        Gizmos.DrawLine(p1, p2);
    }
}
