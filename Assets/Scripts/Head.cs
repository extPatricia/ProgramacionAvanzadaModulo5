using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Head : MonoBehaviour
{
    // Attributes
    [System.NonSerialized]
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddForce(float force)
    {
        GetComponent<Rigidbody>().AddForce(0, force, 0);
    }
}
