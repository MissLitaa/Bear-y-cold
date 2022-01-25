using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSecs : MonoBehaviour
{
    private float destroySecs = 2f;
    
    // Update is called once per frame
    void Update()
    {
        Object.Destroy(gameObject, destroySecs);
    }
}
