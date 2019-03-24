using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cam;

    private float sprint = 1f;
    private float distToGround;

    public Inventory inventory;
    // Walking
    [Header("Movement")]
    public float walkSpeed = 0.5f;
    public float strafeSpeed = 0.4f;
    public float sprintMultiplier = 2f;

    // Looking
    [Header("Looking")]
    public float horizontalSensitivity;
    public float verticalSensitivity;

    // Jumping
    [Header("Jumping")]
    public float jumpForce = 2.0f;
    public float fallForce = 2.0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0).gameObject;

        distToGround = GetComponent<Collider>().bounds.extents.y;
    }


    private void Update()
    {
        // Camera Up & Down
        cam.transform.localEulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * verticalSensitivity, 0, 0);


        // Player Left & Right
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * horizontalSensitivity * Time.deltaTime);


        // Player movement
        if (Input.GetButtonDown("Sprint"))
        {
            sprint = sprintMultiplier;
        }
        else if (Input.GetAxis("Horizontal").Equals(0) && Input.GetAxis("Vertical").Equals(0))
        {
            sprint = 1f;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * strafeSpeed, 0, Input.GetAxis("Vertical") * walkSpeed);
        rb.AddRelativeForce(movement * sprint * Time.deltaTime, ForceMode.Impulse);


        // Player Jump
        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            sprint = sprint >= sprintMultiplier ? sprintMultiplier * 1.5f : 1.5f;
            rb.AddForce(Vector3.down * fallForce, ForceMode.Impulse);
        }
    }


    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }
    //Inventory

}
