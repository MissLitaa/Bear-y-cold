using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement speed.
    public float runSpeed = 25f;

    //Turn speed.
    public float turnSpeed = 100;

    //Axis.
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    public GameObject player;
 

    //Initial position vector.

    void Start()
    {
        transform.position = new Vector3(3f,1.2f,-13f);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Assigns the axis.
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Movement command + run always looking towards Player front.
        rb.AddForce(transform.forward * runSpeed * verticalInput);
        rb.AddTorque(player.transform.up * turnSpeed * horizontalInput);
       
    }
}
