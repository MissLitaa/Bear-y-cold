using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectileForward : MonoBehaviour
{
    public float proyectileSpeed = 50f;
    public GameObject snowBlowPS;

    void Update()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * proyectileSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemy"))
        {
            Instantiate(snowBlowPS, transform.position, Quaternion.identity);
            //Animation girl scout death here.
            Destroy(gameObject);
            //Generate coins. Call to coin script here.
        }
    }

}
