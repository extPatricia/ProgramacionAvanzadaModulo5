using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    //Attributes
    public float repeatRate = 1;
    public GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Drop), 0, repeatRate);
    }

    // Update is called once per frame
    void Drop()
    {
        //Instanciamos el objeto original ballPrefa en las posicion dada, con rotacion zero. 
        //Guardamos la bola instanciada en ball, aunque no hagamos nada con ella.
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }
}
