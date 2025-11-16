using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseRaycast : MonoBehaviour
{
    // Attributes
    public Camera mainCamera;
    public Rigidbody objectSelected = null;

    // Unity callbacks
    void FixedUpdate()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.blue);
            //Debug.Log("Hit: " + hit.collider.name);
            //Debug.Log("Point: " + hit.point);
            //Debug.Log("Normal: " + hit.normal);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Clicked on: " + hit.collider.name);
                //hit.collider.gameObject.SetActive(false);
                objectSelected = hit.rigidbody;
            }
        }
    }
}
