using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string itemType;

    private void Awake()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
        {
            mesh.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
