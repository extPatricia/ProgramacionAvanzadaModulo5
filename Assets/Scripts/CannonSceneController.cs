using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSceneController : MonoBehaviour
{
    // Attributes
    [Range(30,80)]
    public float cannonAngle = 45.0f;
    [Range(100,1000)]
    public float launchForce = 500.0f;
    public Transform cannonTransform;
    public Transform cannonSpawnPoint;
    public Rigidbody cubeRigidbody;
    public Rigidbody sphereRigidbody;
    public CameraMouseRaycast cameraMouseRaycast;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cannonTransform.rotation = Quaternion.Euler(cannonAngle, 0, 0);
        if (cameraMouseRaycast.objectSelected != null)
        {
            cameraMouseRaycast.objectSelected.transform.position = cannonSpawnPoint.position;
            cameraMouseRaycast.objectSelected.AddForce(cannonTransform.up * launchForce);

            cameraMouseRaycast.objectSelected = null;

        }
    }


}
