using UnityEngine;

public class PrimeTester :MonoBehaviour
{
    [SerializeField] int number;
    [SerializeField] bool isPrime;

    void OnValidate()
    {
        isPrime = IsPrime(number);
    }

    bool IsPrime(int number)
    { 
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}