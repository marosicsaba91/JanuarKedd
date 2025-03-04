using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float startHP = 100;
    [SerializeField] Behaviour disableObject;
    [SerializeField] bool destroyOnDeath;
    [SerializeField] GameObject[] spawnOnDeath;

    float currentHP;

    void Start()
    {
        currentHP = startHP;
    }

    public void Damage(float damage)
    {
        if (currentHP <= 0)
            return;

        currentHP -= damage;
        currentHP = Mathf.Max(0, currentHP);

        if (currentHP <= 0)
            OnDeath();
    }

    void OnDeath()
    {
        if(disableObject != null)
            disableObject.enabled = false;

        if (destroyOnDeath)
            Destroy(gameObject);

        foreach (GameObject item in spawnOnDeath)
        {
            Instantiate(item, transform.position, transform.rotation);
        }
    }
}
