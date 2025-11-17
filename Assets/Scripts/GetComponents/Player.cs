using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributes
    public float headForce = 10f;
    private Body body;
    private Head head;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponentInChildren<Body>(true);
        head = GetComponentInChildren<Head>(true);
        head.GetComponent<Rigidbody>();

        body.gameObject.SetActive(true);
        head.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            head.AddForce(300);
        }

        body.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 5, 0, Input.GetAxis("Vertical") * Time.deltaTime * 5);

        
    }

    private void FixedUpdate()
    {
        Vector3 headDirection = body.transform.position - head.transform.position;
        head.rb.AddForce(headDirection * headForce);
    }
}
