﻿using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float translation = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
       float side = Input.GetAxis("Horizontal") * Time.deltaTime * sideSpeed;
        float h = horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        float v = verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        transform.Translate(side, 0, translation);
        transform.Rotate(-v, h, 0);
        if (rb.velocity.sqrMagnitude < 0.1) {
            float j = jumpForce * Input.GetAxis("Jump");
            transform.Translate(0, j, 0);
        }
    } 
}