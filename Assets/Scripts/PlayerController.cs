using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float angularSpeed = 360;

    // [SerializeField] Transform cameraTransform;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Camera c = Camera.main;
        Transform cameraTransform = c.transform;

        // Vector3 direction = new(h, 0, v);
        Vector3 direction = v * cameraTransform.forward + h * cameraTransform.right;

        direction.y = 0;
        direction.Normalize();

        transform.position += direction * speed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float angle = angularSpeed * Time.deltaTime;

            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, targetRotation, angle);
        }
    }
}