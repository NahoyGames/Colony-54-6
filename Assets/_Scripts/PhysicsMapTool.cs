using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMapTool : MonoBehaviour
{
    public GameObject[] rocks;
    public GameObject[] trees;
    public GameObject[] folliage;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        transform.localEulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * 5, Input.GetAxis("Mouse X") * 5, 0);

        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 0.3f, Space.Self);
        transform.position += Vector3.up * Input.GetAxis("Up") * 0.2f;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject g = Instantiate(rocks[Random.Range(0, rocks.Length)], this.transform.position, Quaternion.identity);

            PhysicsDrop p = g.AddComponent<PhysicsDrop>();

            p.deleteRigidbody = true;
            p.sproutMode = false;
            p.minSize = 1.5f;
            p.maxSize = 10f;

            Rigidbody rb = g.AddComponent<Rigidbody>();

            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }
    }
}
