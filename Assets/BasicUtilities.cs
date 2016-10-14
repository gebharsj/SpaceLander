using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class BasicUtilities<T> : MonoBehaviour
{
    static List<T> onlyOnceValues = new List<T>();

    public static int checkIncrement(int value, T[] array)
    {
        value++;

        if (value >= array.Length)
            value = 0;

        return value;
    }

    public static int checkIncrement(int value, List<T> array)
    {
        value++;

        if (value >= array.Count)
            value = 0;

        return value;
    }

    public static int checkIncrement(int value, int maxValue)
    {
        value++;

        if (value >= maxValue)
            value = 0;

        return value;
    }

    public static bool onlyOnce(T checkValue)
    {
        return uniqInsert(checkValue, onlyOnceValues);
    }

    public static void resetOnce(T checkValue)
    {
        if (onlyOnceValues.Contains(checkValue))
            onlyOnceValues.Remove(checkValue);
        else
            Debug.LogError("You tried to remove something that hasn't been added.");
    }

    public static void updateCoroutine(float waitTime)
    {
        //StartCoroutine(waitTime);
    }

    public static bool uniqInsert(T checkValue, List<T> valueList)
    {
        if (!valueList.Contains(checkValue))
        {
            onlyOnceValues.Add(checkValue);
            return true;
        }
        else
            return false;
    }
}
