using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    // Attributes
    public bool floorContact;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
            Debug.Log("Player hit the ball");
        if (collision.gameObject.tag == "Floor")
            floorContact = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            floorContact = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Player mark a goal!");
        }
    }
}
