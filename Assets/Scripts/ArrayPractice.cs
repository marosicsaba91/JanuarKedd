using UnityEngine;

public class ArrayPractice : MonoBehaviour
{
    [SerializeField] int[] intArray;
    [SerializeField] int length = 10;
    [SerializeField] float mean;

    void OnValidate()
    {
        mean = Mean(intArray);
    }

    void Awake()
    {
        // n Elemû int tömb.  Feltöltve: 1, 2, 3, ..., n

        intArray = new int[length];

        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = i + 1;
        }

        // -------------------------------------

        // Komponenst lekérdezések
        GameObject go = GameObject.Find("Player");  // string alapú keresés


        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();       // 
        Rigidbody2D rb2 = FindAnyObjectByType<Rigidbody2D>();  //

        Rigidbody2D[] rb3 = go.GetComponents<Rigidbody2D>();
        Rigidbody2D[] rb4 = FindObjectsByType<Rigidbody2D>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

    }

    float Mean(int[] ints) 
    {
        float sum = 0;
        for (int i = 0; i < ints.Length; i++)
        {
            sum += ints[i];
        }

        return sum / ints.Length;
    }

    string[] GetReversed(string[] input) 
    {
        string[] output = new string[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            output[i] = input[^(i + 1)];
        }
        return output;
    }

    string[] Reverse(string[] input)
    {
        for (int i = 0; i < input.Length / 2; i++)
        {
            string temp = input[i];
            input[i] = input[^(i + 1)];
            input[^(i + 1)] = temp;
        }

        return input;
    }


}
