using System.Collections.Generic;
using UnityEngine;

public class ListPractice : MonoBehaviour
{
    void Start()
    {
        List<int> intList = new();

        for (int i = 0; i < 5; i++)
        {
            intList.Add(i + 1);
        }

        // ??? HÁZI ???
        for (int i = 0; i < intList.Count; i+=2)
        {
            intList.RemoveAt(i);
        }

        List<string> strings = new() { "AAA", "BBB", "CCC" };

        strings.Remove("BBB");
        strings[0] = "XXXZZZ";
        Debug.Log(strings[^1]);

        strings.Insert(1, "MMM");
        strings.Clear();

        // ---------------------------------

        bool isCCCin = strings.Contains("CCC");
        int indexOfCCC = strings.IndexOf("CCC");
        strings.Reverse();

        strings.Sort();

        // ------------------------------------

        char[] chars = { 'a', '?', '8' };  // Zérójelben

        // ------------------------------------

        foreach (string text in strings)
        {
            Debug.Log(text);
        }

        for (int i = 0; i < strings.Count; i++)
        {
            Debug.Log(strings[i]);
        }


    }
}
