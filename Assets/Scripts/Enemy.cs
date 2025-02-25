using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] float smoothTime = 1;
    [SerializeField] float moveDelay = 10;
    [SerializeField] float shootDelay = 5;
    [SerializeField] Projectile bullet;

    float moveTimer;
    float shootTimer;
    Vector3 targetPosition;
    Vector3 velocity;

    CameraManager cameraManager;
    SpaceshipController spaceshipController;

    void Start()
    {
        cameraManager = FindAnyObjectByType<CameraManager>();
        spaceshipController = FindAnyObjectByType<SpaceshipController>();

        MoveToNext();
    }


    void Update()
    {
        moveTimer += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (moveTimer >= moveDelay)
        {
            MoveToNext();
            moveTimer -= moveDelay;
        }

        if (shootTimer >= shootDelay)
        {
            Shoot();
            shootTimer -= shootDelay;
        }

        // ???
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime);
    }

    void MoveToNext()
    {
        Rect cameraRect = cameraManager.GetCameraRect();
        float x = Random.Range(cameraRect.xMin, cameraRect.xMax);
        float y = Random.Range(cameraRect.yMin, cameraRect.yMax);
        targetPosition = new(x, y);

        //      DETERMINISZTIKUS:
        //      System.Random random = new (1001012);
        //      random.NextDouble();
    }

    void Shoot()
    {
        if (spaceshipController == null) return;

        Vector3 spaceshipPoint = spaceshipController.transform.position;
        Vector3 selfPoint = transform.position;

        Vector3 direction = spaceshipPoint - selfPoint;
        direction.Normalize();

        
        float angleRad = Mathf.Atan2(direction.y, direction.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;
        angleDeg -= 90;       

        // ALTERNATÍVA:
        // float angleDeg = Vector2.SignedAngle(Vector2.up, direction);

        Quaternion projectileRotation = Quaternion.Euler(0, 0, angleDeg);

        Projectile newProjectile =
             Instantiate(bullet, transform.position, projectileRotation);

        newProjectile.SetStartVelocity(Vector3.zero);
    }

}
