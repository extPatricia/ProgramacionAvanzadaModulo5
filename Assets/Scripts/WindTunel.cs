using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTunel : MonoBehaviour
{
    // Attributes
    public float forceStrength = 10f;
    Rigidbody objectIn = null;
    
    //private void OnTriggerStay(Collider other)
    //{
    //    other.GetComponent<Rigidbody>().AddForce(Vector3.up * forceStrength);
    //}

    private void OnTriggerEnter(Collider other)
    {
        objectIn = other.GetComponent<Rigidbody>();
        objectIn.velocity = Vector3.zero; // Reset velocity to avoid sudden jumps
    }

    private void OnTriggerExit(Collider other)
    {
        objectIn = null;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (objectIn != null)
        {
            objectIn.AddForce(Vector3.up * forceStrength);
        }
    }
}
