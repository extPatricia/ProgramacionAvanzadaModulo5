using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
            //Debug.Log("Hit: " + hit.collider.name);
            //Debug.Log("Point: " + hit.point);
            //Debug.Log("Normal: " + hit.normal);
        }

        //if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit))
        //{
        //    Debug.DrawLine(transform.position, hit.point, Color.blue);
        //    Debug.Log("Sphere Hit: " + hit.collider.name);
        //}

    }
}
