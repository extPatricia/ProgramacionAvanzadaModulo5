using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Attributes
    [System.NonSerialized]
    public Rigidbody rb;

    public DataKPI kpiData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (kpiData != null)
            kpiData.SendData();
    }
}
