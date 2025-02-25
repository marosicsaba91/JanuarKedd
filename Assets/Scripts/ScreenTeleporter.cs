using UnityEngine;

public class ScreenTeleporter : MonoBehaviour
{
    [SerializeField] Collider2D coll;

    void FixedUpdate()
    {
        Camera c = Camera.main;

        float sizeY = c.orthographicSize * 2;
        Vector2 cameraSize = new(sizeY * c.aspect, sizeY);
        Vector2 cameraCenter = c.transform.position;

        Rect cameraRect = new(cameraCenter - (cameraSize / 2), cameraSize);

        Bounds objectBound = coll.bounds;
        Rect objectRect = new(objectBound.min, objectBound.center);

        if (!cameraRect.Overlaps(objectRect))
        {
            if (cameraRect.xMax < objectRect.xMin)  // Jobb oldalt 
                transform.position = new(cameraRect.xMin - objectRect.size.x / 2, transform.position.y);
            else if (cameraRect.xMin > objectRect.xMax)  // Bal oldalt 
                transform.position = new(cameraRect.xMax + objectRect.size.x / 2, transform.position.y);

            if (cameraRect.yMax < objectRect.yMin)  // Fent 
                transform.position = new(transform.position.x, cameraRect.yMin - objectRect.size.y / 2);
            else if (cameraRect.yMin > objectRect.yMax)  // Lent
                transform.position = new(transform.position.x, cameraRect.yMax + objectRect.size.y / 2);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(coll.bounds.center, coll.bounds.size);        
    }
}
