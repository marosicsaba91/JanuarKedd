using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float rotSpeed = 60;
    [SerializeField] float angleToRotate = 45;
    float targetAngle;
    int rotDirection;

    void Update()
    {
        float currentAngle = transform.rotation.eulerAngles.z;
        if (currentAngle < 0)
            currentAngle += 360;

        if (rotDirection == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetAngle = currentAngle + angleToRotate;
                rotDirection = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetAngle = currentAngle - angleToRotate;
                rotDirection = -1;
            }
        }
        else
        {
            transform.RotateAround(Vector3.zero, Vector3.forward * rotDirection, Time.deltaTime * rotSpeed);
            if (rotDirection > 0 && currentAngle >= targetAngle || rotDirection < 0 && currentAngle <= targetAngle)
            {
                rotDirection = 0;
                transform.rotation = Quaternion.Euler(0, 0, targetAngle);
            }

        }


    }

}
