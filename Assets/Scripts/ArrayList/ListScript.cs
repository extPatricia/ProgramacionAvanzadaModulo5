using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListScript : MonoBehaviour
{
    // Attributes
    public int limitObjects = 20;
    public List<GameObject> objectList = new List<GameObject>();
    public GameObject explotionPrefab;
    public DataKPI kpiExplotion;
    public DataKPI kpiSpawbData;

    // Methods
    public void AddObject(GameObject ball)
    {
        objectList.Add(ball);
        if (objectList.Count > limitObjects)
            ExplotionAll();

        if (kpiSpawbData != null)
            kpiSpawbData.SendData();
    }

    private void ExplotionAll()
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            Destroy(objectList[i]);
            Instantiate(explotionPrefab, objectList[i].transform.position, Quaternion.identity);
        }
        objectList.Clear(); 

        if (kpiExplotion != null)
            kpiExplotion.SendData();
    }
}
