using System.Collections.Generic;
using UnityEngine;

public class ArrayHomework : MonoBehaviour
{
    [SerializeField] int task1_input = 1;
    [SerializeField] int[] task1_output;

    [SerializeField] int task2_input = 1;
    [SerializeField] int[] task2_output;

    [SerializeField] List<string> task3;


    [SerializeField] string[] task4_input1;
    [SerializeField] string[] task4_input2;
    [SerializeField] string[] task4_output;

    [SerializeField] int task5_input = 1;
    [SerializeField] int[] task5_output;

    [SerializeField] int[] task6;

    void OnValidate()
    {
        task1_output = CreateArray_2(task1_input);
        task2_output = CreateArray_3_v2(task2_input);
        task4_output = MergeArries(task4_input1, task4_input2);

        task5_output = GetFibonacci(task5_input);
    }

    void Start()
    {
        RemoveEverySecond(task3);
        task6 = Lotto(70, 6);

        // Érték típus
        int a = 5;
        int b = a;  // Másolat készül
        b++;
        Debug.Log(a);  // 5

        // -----------------

        // Referencia Típusok
        int[] c = { 1, 10, 100 };
        int[] d = c;   // Rámutat
        d[0]++;
        Debug.Log(c[0]);  // 2

    }



    int[] CreateArray_2(int length) 
    {
        int[] ints = new int[length];

        int numbersFound = 0;

        for (int i = 1; numbersFound < length; i++)
        {
            if (i % 4 != 0 && i % 5 != 0)
            {
                ints[numbersFound] = i; 
                numbersFound++;
            }
        }

        return ints;
    }

    int[] CreateArray_3(int max)
    {
        int numbersFound = 0;

        for (int i = 1; i <= max; i++)
        {
            if (i % 4 != 0 && i % 5 != 0)
            {
                numbersFound++;
            }
        }
        int[] ints = new int[numbersFound];

        numbersFound = 0;

        for (int i = 1; i <= max; i++)
        {
            if (i % 4 != 0 && i % 5 != 0)
            {
                ints[numbersFound] = i;
                numbersFound++;
            }
        }

        return ints;
    }

    int[] CreateArray_3_v2(int max)
    {
        List<int> numbers = new();

        for (int i = 1; i <= max; i++)
        {
            if (i % 4 != 0 && i % 5 != 0)
            {
                numbers.Add( i);
            }
        }

        return numbers.ToArray();
    }

    void RemoveEverySecond(List<string> list)
    {
        // Ellenőrizzük, hogy a lista hossza páros-e
        bool isEven = list.Count % 2 == 0;

        // Ha páros, az utolsó elemtől kezdjük, ha páratlan, az utolsó előtti elemtől
        int startIndex = isEven ? (list.Count - 1) : (list.Count - 2);

        // Végigmegyünk a listán visszafelé, és minden második elemet eltávolítunk
        // Azért visszafelé, mert ha előre mennénk, akkor az eltávolítás miatt az indexek megváltoznának 
        for (int i = startIndex; i >= 0; i -= 2)
        {
            // Kiveszem az elemet ami az i-edik helyen van
            list.RemoveAt(i);
        }
    }

    string[] MergeArries(string[] a, string[] b)
    {
        string[] strings = new string[a.Length + b.Length];

        for (int i = 0; i < a.Length; i++)
        {
            strings[i] = a[i];
        }

        for (int i = 0; i < b.Length; i++)
        {
            strings[i + a.Length] = b[i];
        }

        return strings;
    }

    int CountCharacters(string text) 
    {
        List<char> chars = new();

        foreach (char c in text)
        {
            if (!chars.Contains(c))
                chars.Add(c);
        }

        return chars.Count;
    }

    int[] GetFibonacci(int count) 
    {
        int[] fibonacci = new int[count];

        if (count >= 1)
            fibonacci[0] = 0;
        if (count >= 2)
            fibonacci[1] = 1;

        for (int i = 2; i < count; i++)
        {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2]; 
        }

        return fibonacci;
    }

    int[] Lotto(int numberCount = 90, int itemsChosen = 5) 
    {
        List<int> lotto = new();

        for (int i = 1; i <= numberCount; i++)
        {
            lotto.Add(i);
        }

        int[] winners = new int[itemsChosen];
        for (int i = 0; i < itemsChosen; i++)
        {
            int winnerIndex = Random.Range(0, lotto.Count); 
            winners[i] = lotto[winnerIndex];
            lotto.RemoveAt(winnerIndex);


        }

        return winners;
    }

}