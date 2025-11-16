using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartboardScore : MonoBehaviour
{
    public float scoreValue;
    public static float totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Score: " + scoreValue);
        totalScore += scoreValue;
        print("Total Score: " + totalScore);
    }
}
