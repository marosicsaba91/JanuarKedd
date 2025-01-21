using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform target;

    void Update()
    {
        transform.position = 
            Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
        
    }
}
