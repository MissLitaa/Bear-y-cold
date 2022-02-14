using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectileForward : MonoBehaviour
{
    public float proyectileSpeed = 50f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * proyectileSpeed);
    }
}
