using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float startHP = 100;
    [SerializeField] Behaviour disableObject;

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
            disableObject.enabled = false;
    }
}
