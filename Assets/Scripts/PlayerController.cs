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

    //Initial position vector.

    void Start()
    {
        transform.position = new Vector3(3,1,-13);
    }

    void Update()
    {
        //Assigns the axis.
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Movement command + run always looking towards Player front.
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput, Space.World);
        transform.Translate(Vector3.forward * Time.deltaTime * runSpeed * verticalInput, Space.Self);

    }
}
