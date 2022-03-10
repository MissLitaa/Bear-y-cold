using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectileForward : MonoBehaviour
{
    public float proyectileSpeed = 50f;
    public GameObject snowBlowPS;

    //Audio
    public AudioSource girlScoutAS;
    public AudioClip girlScoutAC;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * proyectileSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enemy"))
        {
            girlScoutAS.PlayOneShot(girlScoutAC, 1);
            Instantiate(snowBlowPS, transform.position, Quaternion.identity);
            //Animation girl scout death here.
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("girl scout has been hit");
            //Generate coins. Call to coin script here.
        }
    }

}
