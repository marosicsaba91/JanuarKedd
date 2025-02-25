using UnityEngine;

public class MoveTowardsLimit : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxDistance;

    Vector3 startPoint;

    void Start()
    {
        startPoint = transform.position;
    }


    void Update()
    {
        Vector3 distanceVector = target.position - startPoint;

        distanceVector = Vector3.ClampMagnitude(distanceVector, maxDistance);

        transform.position = startPoint + distanceVector;

    }
}
