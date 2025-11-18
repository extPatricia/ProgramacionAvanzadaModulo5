using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperCorrutine : MonoBehaviour
{
    //Attributes
    public GameObject ballPrefab;
    public float minRange = 0f;
    public float maxRange = 2f;

    // Private attributes
    private MyArray myArray;
    private ListScript myList; 

    // Methods
    private void Awake()
    {
        myArray = GetComponent<MyArray>();
        myList = GetComponent<ListScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        float repeatRate = Random.Range(minRange, maxRange);
        StartCoroutine(Drop(repeatRate));
    }

    IEnumerator Drop(float rate)
    {
        // Wait one frame before starting
        // yield return null;

        // Wait for the specified repeat rate
        // In start or update explots
        while (true)
        {
            float probability = Random.Range(0, 3);
            if (probability == 0)
            { 
                GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
                if (myArray != null)
                {
                    myArray.AddObject(ball);
                }
                if (myList != null)
                {
                    myList.AddObject(ball);
                }

            }
            // Wait for the specified repeat rate before dropping the next ball
            yield return new WaitForSeconds(rate);
        }        
    }
}
