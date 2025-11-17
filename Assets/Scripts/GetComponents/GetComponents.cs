using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class GetComponents : MonoBehaviour
{
    // Attributes
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
          GetComponent<MeshRenderer>().material.color = color;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(0, 500, 0);
            GetComponentInChildren<Head>().AddForce(300);

            // Disable the MeshRenderer of the parent beacuse GetComponentInChildren also works on the parent if has a component of the specified type
            //GetComponentInChildren<MeshRenderer>().enabled = false;

            Camera.main.fieldOfView *= 2; // me alejo
            Camera.main.transform.Translate(0, 0, 5);
        }

    }
}
