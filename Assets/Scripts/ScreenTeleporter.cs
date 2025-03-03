using UnityEngine;

public class ScreenTeleporter : MonoBehaviour
{
    [SerializeField] Collider2D coll;

    CameraManager cameraManager;

    void Start()
    {
        cameraManager = FindAnyObjectByType<CameraManager>();
    }

    void FixedUpdate()
    {
        Rect cameraRect = cameraManager.GetCameraRect();
        Bounds objectBound = coll.bounds;

        Rect objectRect = new(objectBound.min, objectBound.size);

        if (!cameraRect.Overlaps(objectRect))
        {
            if (cameraRect.xMax < objectRect.xMin)  // Jobb oldalt 
                transform.position += Vector3.left * (cameraRect.size.x + objectRect.size.x);
            else if (cameraRect.xMin > objectRect.xMax)  // Bal oldalt 
                transform.position += Vector3.right * (cameraRect.size.x + objectRect.size.x);

            if (cameraRect.yMax < objectRect.yMin)  // Fent 
                transform.position += Vector3.down * (cameraRect.size.y + objectRect.size.y);
            else if (cameraRect.yMin > objectRect.yMax)  // Lent
                transform.position += Vector3.up * (cameraRect.size.y + objectRect.size.y);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(coll.bounds.center, coll.bounds.size);        
    }
}
