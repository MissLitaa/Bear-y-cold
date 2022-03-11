using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectileForward : MonoBehaviour
{
    public float proyectileSpeed = 50f;
    public GameObject snowBlowPS;
    public GameObject coinFBX;
    public coinBehaviour coinBeh;

    //AS
    public AudioSource GSAudioSource;
    public AudioClip GSAudioClip;
    public bool girlIsHit;

    private void Start()
    {
        coinBeh = FindObjectOfType<coinBehaviour>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * proyectileSpeed);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            girlIsHit = true;
            if (girlIsHit == true)
            {
                GSAudioSource.PlayOneShot(GSAudioClip, 1);
                Instantiate(snowBlowPS, transform.position, Quaternion.identity);
                //Animation girl scout death here.
                scoutDeath();
                Destroy(other.gameObject);
                Debug.Log("girl scout has been hit");
                //Generate coins. Call to coin script here.
                Instantiate(coinFBX, transform.position, Quaternion.identity);
            }

        }
        girlIsHit = false;

    }

    IEnumerator scoutDeath()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
        
    }

}
