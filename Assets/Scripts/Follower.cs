using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float range = 5;
    [SerializeField] Transform target;

    void Update()
    {
        Vector3 distanceVector = target.position - transform.position;
        float distance = distanceVector.magnitude;
        
        if (distance > range)
            return;

        transform.position = 
            Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(distanceVector != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(distanceVector);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
