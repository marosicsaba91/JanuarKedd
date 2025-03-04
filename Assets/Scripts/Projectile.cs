using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float duration = 5;

    float age;
    Vector3 velocity;

    public void SetStartVelocity(Vector3 startVelocity)
    {
        velocity = startVelocity + transform.up * speed;
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        age += Time.deltaTime;
        if (duration <= age)
        {
            Destroy(gameObject);
        }
    }


}
