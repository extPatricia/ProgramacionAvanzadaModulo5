using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KPIType
{
    CollisionKPI,
    SpawnedBallsKPI,
    ExplodedBallsKPI
}

public class DataKPI : MonoBehaviour
{
    // Attributes
    public KPIType kpiType;

    private DataController dataController;

    // Methods
    private void Awake()
    {
        dataController = FindObjectOfType<DataController>();
    }
    public void SendData()
    {
        print("KPI Sent: " + kpiType.ToString());
        dataController.CollectData(kpiType);
    }
}
