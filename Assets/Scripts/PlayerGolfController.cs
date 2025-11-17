using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerGolfController : MonoBehaviour
{
    // Attributes
    public float moveSpeed = 15f;
    public LineRenderer line;

    private Vector3 dragStartPoint;
    private Vector3 dragEndPoint;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // On mouse button down, record the drag start point
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                dragStartPoint = hit.point; 
            }
        }

        // While mouse button is held, update the drag end point and show prediction
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                dragEndPoint = hit.point;

                Vector3 direction = dragStartPoint - dragEndPoint;
                direction.y = 0;

                ShowPrediction(direction);
            }
        }

        // On mouse button up, record the drag end point and apply force
        if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                dragEndPoint = hit.point;
                Vector3 forceDirection = dragStartPoint - dragEndPoint;
                forceDirection.y = 0; // Keep the force horizontal

                float distance = Vector3.Distance(dragStartPoint, dragEndPoint);
                float finalForce = distance * moveSpeed;
                finalForce = Mathf.Clamp(finalForce, 0, moveSpeed);

                rb.AddForce(forceDirection.normalized * finalForce, ForceMode.Impulse);
            }
        }
    }

    void ShowPrediction(Vector3 direction)
    {
        line.enabled = true;
        line.positionCount = 2;
        line.SetPosition(0, transform.position);
        Vector3 predictedEndPoint = transform.position + direction.normalized * moveSpeed;
        line.SetPosition(1, predictedEndPoint);
    }
}
