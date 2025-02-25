using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] float angularSpeed = 90;
    [SerializeField] float maxSpeed = 1;
    [SerializeField] float acceleration = 10;
    [SerializeField] float drag = 0.5f;

    [SerializeField] Projectile bullet;

    Vector3 velocity;

    void Update()
    {
        // Lövés --------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Projectile newProjectile = 
                Instantiate(bullet, transform.position, transform.rotation);
            newProjectile.SetStartVelocity(velocity);
        }

        // Forgás -------------------------------------

        float rotationInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0,0, -rotationInput * angularSpeed * Time.deltaTime);

        /*
        float roation2D = transform.rotation.eulerAngles.z;
        roation2D -= rotationInput * angularSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,0,roation2D);
        */

        // Haladás ---------------------------------------

        transform.position += velocity * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // Gyorsulás -----------------------------------------------

        float movementInput = Input.GetAxisRaw("Vertical");
        movementInput = Mathf.Max(movementInput, 0);
        Vector3 accelerationVector = transform.up * movementInput * acceleration;

        velocity += accelerationVector * Time.fixedDeltaTime;

        // Lassulás ----------------------------------------------------

        Vector3 dragVector = -velocity * drag;
        velocity += dragVector * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
    }


}