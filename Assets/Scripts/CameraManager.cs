using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera cam;

    Rect cameraRect;

    public Rect GetCameraRect() 
    {
        return cameraRect;
    }

    void OnValidate()
    {
        if (cam == null)
            cam = GetComponent<Camera>();
    }

    void Awake()
    {
        Calculate();
    }

    void Update()
    {
        Calculate();
    }

    void Calculate()
    {
        float sizeY = cam.orthographicSize * 2;
        Vector2 cameraSize = new(sizeY * cam.aspect, sizeY);
        Vector2 cameraCenter = cam.transform.position;

        cameraRect = new(cameraCenter - (cameraSize / 2), cameraSize);
    }
}
