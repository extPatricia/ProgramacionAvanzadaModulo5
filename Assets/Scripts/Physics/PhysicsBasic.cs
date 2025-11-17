using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBasic : MonoBehaviour
{
    // Attributes
    public Rigidbody playerRigidbody;
    public float jumpForce = 500f;
    public float moveForce = 10f;
    public Detector detector;

    // Start is called before the first frame update
    void Start()
    {
        //playerRigidbody.AddForce(0, 500, 0);
        //playerRigidbody.AddForce(Vector3.up * 500);
    }

    void Update()
    {
        print("Velocity: " + playerRigidbody.velocity);

        //Jump when space is pressed
         if (Input.GetKeyUp(KeyCode.Space) && detector.floorContact == true)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }

    // FixedUpdate is for physics updates
    void FixedUpdate()
    {
        playerRigidbody.AddForce(Input.GetAxis("Horizontal") * moveForce, 0, Input.GetAxis("Vertical") * moveForce);
    }

}
