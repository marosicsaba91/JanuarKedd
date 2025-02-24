using UnityEngine;

public class PoseVisualizer : MonoBehaviour
{
    [SerializeField] float length = 1;

    void OnDrawGizmos()
    {
        DrawAxis(transform.right, Color.red);
        DrawAxis(transform.up, Color.green);
        DrawAxis(transform.forward, Color.blue);
    }

    void DrawAxis(Vector3 direction, Color color)
    {
        Gizmos.color = color;
        Vector3 c = transform.position;
        Vector3 scaledDir = direction * length;
        Gizmos.DrawLine(c + scaledDir, c - scaledDir);
        Gizmos.DrawSphere(c + scaledDir, length * 0.1f);
    }
}
