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
        // Rect objectRect = new(objectBound.min, objectBound.center);
        Rect objectRect = new(objectBound.min, objectBound.size);

        if (!cameraRect.Overlaps(objectRect))
        {
            if (cameraRect.xMax < objectRect.xMin)  // Jobb oldalt 
                transform.position = new(cameraRect.xMin + objectRect.size.x / 2, transform.position.y);
            else if (cameraRect.xMin > objectRect.xMax)  // Bal oldalt 
                transform.position = new(cameraRect.xMax - objectRect.size.x / 2, transform.position.y);

            if (cameraRect.yMax < objectRect.yMin)  // Fent 
                transform.position = new(transform.position.x, cameraRect.yMin + objectRect.size.y / 2);
            else if (cameraRect.yMin > objectRect.yMax)  // Lent
                transform.position = new(transform.position.x, cameraRect.yMax - objectRect.size.y / 2);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(coll.bounds.center, coll.bounds.size);        
    }
}
