using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] float angularSpeed = 90;
    [SerializeField] float maxSpeed = 1;
    [SerializeField] float acceleration = 10;
    // [SerializeField] float drag = 0.5f;

    [SerializeField] Projectile[] bullets;

    int bulletIndex = 0;

    Rigidbody2D rigidBody;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lövés --------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int i = bulletIndex % bullets.Length;

            Projectile newProjectile =
                Instantiate(bullets[i], transform.position, transform.rotation);
            newProjectile.SetStartVelocity(rigidBody.linearVelocity);

            bulletIndex++;
        }

        // Forgás -------------------------------------

        float rotationInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0,0, -rotationInput * angularSpeed * Time.deltaTime);
        rigidBody.rotation = transform.rotation.eulerAngles.z;

        /*
        float roation2D = transform.rotation.eulerAngles.z;
        roation2D -= rotationInput * angularSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,0,roation2D);
        */

        // Haladás ---------------------------------------

        // transform.position += velocity * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // Gyorsulás -----------------------------------------------

        float movementInput = Input.GetAxisRaw("Vertical");
        movementInput = Mathf.Max(movementInput, 0);
        Vector2 accelerationVector = transform.up * movementInput * acceleration;

        rigidBody.linearVelocity += accelerationVector * Time.fixedDeltaTime;

         rigidBody.AddForce(accelerationVector, ForceMode2D.Force);

        // Lassulás ----------------------------------------------------
        /*
        Vector3 dragVector = -velocity * drag;
        velocity += dragVector * Time.fixedDeltaTime;
        */

        rigidBody.linearVelocity = Vector3.ClampMagnitude(rigidBody.linearVelocity, maxSpeed);
    }


}