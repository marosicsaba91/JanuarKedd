using UnityEngine;

public class FollowCloser : MonoBehaviour
{
    [SerializeField] Transform target1, target2;
    [SerializeField] float speed = 1;
    
    void Update()
    {
        if (target1 == null && target2 == null)
            return;

        float distance1 = target1 == null ? float.PositiveInfinity : Vector3.Distance(target1.position, transform.position);
        float distance2 = target2 == null ? float.PositiveInfinity : Vector3.Distance(target2.position, transform.position);

        Transform target = distance1 < distance2 ? target1 : target2;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
