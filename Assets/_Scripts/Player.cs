using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject cam;

    private float sprint = 1f;


    // Walking
    [Header("Movement")]
    public float walkSpeed = 0.5f;
    public float strafeSpeed = 0.4f;
    public float sprintMultiplier = 2f;

    // Looking
    [Header("Looking")]
    public float horizontalSensitivity;
    public float verticalSensitivity;

    public float jumpForce = 2.0f;
    public float isSprinting = 1.0f;
    public float multiplier = 1.0f;
    public float didNot = 1000.0f;
    public float jumpMax = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        /*float translation = Input.GetAxis("Vertical") * Time.deltaTime * Speed * isSprinting;
        float side = Input.GetAxis("Horizontal") * Time.deltaTime * sideSpeed * isSprinting * 0.9f;
        float h = horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        float v = verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        rb.AddRelativeForce(side, 0, translation);
        cam.transform.localEulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * 5, 0, 0);
        rb.AddTorque(Vector3.up * Input.GetAxis("Mouse X") * 5);
        if (Input.GetButton("Sprint")) {
            isSprinting = multiplier;
         }
        else {
            isSprinting = 1;
        }
        if (Input.GetButtonDown("Jump")) {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity)){
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                Debug.Log("Hit");
                Debug.Log(hit.distance);
                if(hit.distance <= jumpMax) {
                    float j = Input.GetAxis("Jump") * jumpForce;
                    rb.AddForce(0, j, 0);
                }
                else {
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * didNot, Color.white);
                Debug.Log("Did not Hit");
                Debug.Log(hit.distance); 
            }
        }*/


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
    }
}
