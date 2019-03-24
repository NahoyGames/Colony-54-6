using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMine : MonoBehaviour
{
    Rigidbody rb;
    public float mineMiss = 1000.0f;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        laser = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Hit");
                Debug.Log(hit.distance);
                Instantiate(laser);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * mineMiss, Color.white);
                Debug.Log("Did not Hit");
                Debug.Log(hit.distance);
            }
        }
    }
}
