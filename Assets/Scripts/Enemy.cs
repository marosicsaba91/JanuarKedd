using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float smoothTime = 1;
    [SerializeField] float moveDelay = 10;
    [SerializeField] float shootDelay = 5;
    [SerializeField] Projectile bullet;

    void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();
    }

    float moveTimer;
    float shootTimer;
    Vector3 targetPosition;

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

        Vector2 v = rigidBody.linearVelocity;

        rigidBody.position = Vector2.SmoothDamp(
            transform.position,
            targetPosition,
            ref v,
            smoothTime);

        rigidBody.linearVelocity = v;
    }

    void MoveToNext()
    {
        targetPosition = cameraManager.GetRandomPositionInCamera();
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
