using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollision : MonoBehaviour
{
    public coinBehaviour coinBeh;

    // Start is called before the first frame update
    void Start()
    {
        coinBeh = FindObjectOfType<coinBehaviour>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coinBeh.AddCoins();
            Destroy(gameObject);
        }
    }

}
