using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float Speed = 1.0f;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float jumpForce = 2.0f;
    public float sideSpeed = 2.0f;
    public float isSprinting = 1.0f;
    public float multiplier = 1.0f;
    public float didNot = 1000.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float translation = Input.GetAxis("Vertical") * Time.deltaTime * Speed * isSprinting;
        float side = Input.GetAxis("Horizontal") * Time.deltaTime * sideSpeed * isSprinting * 0.9f;
        float h = horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        float v = verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        transform.Translate(side, 0, translation);
        transform.Rotate(-v, h, 0);
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
                if(hit.distance <= 1.10) {
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
        }
    } 
}
