using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyArray : MonoBehaviour
{
    // Attributes
    public string[] daysArray = 
    {
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
        "Sunday"
    };
    public GameObject[] objectArray = new GameObject[5];
    public GameObject[] objectArrayInspector;

    // Private attributes
    private int index = 0;
    private int indexInspector = 0;

    // Methods
    public void AddObject(GameObject newObject)
    {
        if (index < objectArray.Length)
        { 
            objectArray[index] = newObject;
            index++;
        }

        // Error control
        if (indexInspector < objectArrayInspector.Length)
        {
            objectArrayInspector[indexInspector] = newObject;
            indexInspector++;
        }
    }
}
