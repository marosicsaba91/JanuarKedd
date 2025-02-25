using UnityEngine;

public class StepCounter : MonoBehaviour
{
    [SerializeField] Vector2 a, b;

    //Kimenetek
    [SerializeField] int stepCount;   
    [SerializeField] Vector2 oneStep;

    void OnValidate()
    {
        Vector2 distanceVector = b - a;

        float distance = distanceVector.magnitude;
        stepCount = Mathf.CeilToInt(distance);

        oneStep = distanceVector / stepCount;
    }

    void Start()
    {
        transform.position = a;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += (Vector3)oneStep;
        } 
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(a, 0.1f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(b, 0.1f);
    }

}