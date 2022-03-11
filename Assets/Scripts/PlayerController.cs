using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement speed.
    private float runSpeed = 600f;

    //Turn speed.
   private float turnSpeed = 50;

    //Axis.
    private float horizontalInput;
    private float verticalInput;

    //Related to Animation and RigidB
    private Rigidbody rb;
    public GameObject player;
    public Animator playerAnimator;
    public AnimationClip playerRunningAnim;

    //Player is moving forward;
    private bool playerIsMovingForward;

    //pAS
    public AudioSource playerAS;
    public AudioClip playerWalk;
    public AudioClip playerHurt;

    void Start()
    {
        transform.position = new Vector3(2.05f, 0.2f, -9.5f);
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAS = GetComponent<AudioSource>();
        playerHurt = GetComponent<AudioClip>();
    }

    void Update()
    {
        playerRunning();
    }

    public void playerRunning()
    {
        //Assigns the axis.
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Movement command + run always looking towards Player front.
        rb.AddForce(transform.forward * runSpeed * verticalInput);
        rb.AddTorque(player.transform.up * turnSpeed * horizontalInput);

        if (Input.GetAxis("Vertical") !=0)
        {
            Debug.Log(playerIsMovingForward);
            playerAnimator.SetBool("isMoving", true);
        }

        else
        {
            playerAnimator.SetBool("isMoving", false);
        }

    }

}
