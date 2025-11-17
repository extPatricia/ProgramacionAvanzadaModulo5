using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    // Attributes
    public float downForce = 5f;
    public Transform ballStartPosition;
    Rigidbody objectIn = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball entered the hole!");
            // Reset ball position
            objectIn = other.GetComponent<Rigidbody>();
            objectIn.velocity = Vector3.zero;
            objectIn.angularVelocity = Vector3.zero;

            objectIn.transform.position = ballStartPosition.position;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        objectIn = null;
    }

    private void FixedUpdate()
    {
        if (objectIn != null)
        {
            objectIn.AddForce(Vector3.down * downForce);
        }
    }
}
