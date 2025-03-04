using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float minStartSpeed = 10;
    [SerializeField] float maxStartSpeed = 20;
    [SerializeField] float minDamage = 10;
    [SerializeField] float maxDamage = 20;
    [SerializeField] float minDamageSpeed = 1;
    [SerializeField] float maxDamageSpeed = 10;

    // [SerializeField] AnimationCurve speedToDamage;

    [SerializeField] float damageDelay = 1;

    bool enableDamage = false;

    void Start()
    {
        Vector3 direction = Random.insideUnitCircle.normalized;
        rigidBody.linearVelocity = direction * Random.Range(minStartSpeed, maxStartSpeed);

        Invoke(nameof(EnableDamage), damageDelay);
    }

    void EnableDamage() 
    {
        enableDamage = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!enableDamage) return;

        if (collision.collider.TryGetComponent(out Damageable d))
        {
            float s = collision.relativeVelocity.magnitude;

            float t = Mathf.InverseLerp(minDamageSpeed, maxDamageSpeed, s);
            float damage = Mathf.Lerp(minDamage,maxDamage, t);

            // float damage = speedToDamage.Evaluate(s);

            d.Damage(damage);
        }
    }
}
