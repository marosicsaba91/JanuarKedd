using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damage = 10;

    void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.Damage(damage);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.Damage(damage);
        }
    }
}
