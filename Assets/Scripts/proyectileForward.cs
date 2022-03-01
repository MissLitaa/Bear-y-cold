using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectileForward : MonoBehaviour
{
    public float proyectileSpeed = 50f;
    public GameObject enemy;
    public ParticleSystem snowBlowPS;
    
    void Update()
    {
        snowBlowPS = GetComponent<ParticleSystem>();
        transform.Translate(Vector3.forward * Time.deltaTime * proyectileSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            snowBlowPS.Emit(5);
            //Animation girl scout death here.
            Destroy(enemy);
            //Generate coins. Call to coin script here.
        }
    }
}
