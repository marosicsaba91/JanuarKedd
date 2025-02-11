using UnityEngine;

[SelectionBase]
public class Rotator : MonoBehaviour
{
    [SerializeField] float angularSpeed = 360;
    [SerializeField] Vector3 axis = Vector3.up;
    [SerializeField] Space space;

    void Update()
    {
        transform.Rotate(axis, angularSpeed * Time.deltaTime, space);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        // Local version

        Vector3 transformedAxis = axis;

        if (space == Space.Self)
        {
            transformedAxis = transform.TransformVector(axis);
        }

        Vector3 p = transform.position;
        Vector3 p1 = p + transformedAxis;
        Vector3 p2 = p - transformedAxis;
        Gizmos.DrawLine(p1, p2);
    }
}
