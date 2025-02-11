using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float angularSpeed = 90;

    Vector3 TargetPoint()
    {
        return target.position + target.TransformVector(offset);
    }

    void Update()
    {
        //transform.LookAt(target);


        Vector3 direction = TargetPoint() - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, angularSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        if (target == null)
            return;


        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(TargetPoint(), Vector3.one * 0.5f);
    }
}
