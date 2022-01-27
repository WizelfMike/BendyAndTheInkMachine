using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float z = 0.5f;
    public float y = 0.5f;
    public float x = 0.5f;

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(x, y, z)); //applying rotation
    }
}
