using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Attributes
    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public float speedRotation = 100;

    [Header("Ball Settings")]
    public Ball ballPrefab;
    public float shootForce = 1000;

    private Quaternion initialRotation;

    private void Awake()
    {
        initialRotation = transform.rotation;
    }
    private void Start()
    {
        Invoke(nameof(InitialConfiguration), 0.1f);
        Cursor.lockState = CursorLockMode.Confined; // Lock cursor to game window
        Cursor.lockState = CursorLockMode.Locked; // Hide cursor
    }
    // Update is called once per frame
    void Update()
    {
        // Rotate shooter based on mouse movement
        transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * speedRotation * Vector3.left);
        transform.Rotate(Input.GetAxis("Mouse X") * Time.deltaTime * speedRotation * Vector3.up);
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x,
            transform.localRotation.eulerAngles.y,
            0);

        // Spawn and shoot ball on left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ball ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            ball.rb.AddForce(transform.forward * shootForce);
        }
    }

    void InitialConfiguration()
    {
        initialRotation = transform.rotation;
    }
}
