using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsDrop : MonoBehaviour
{
    public bool deleteRigidbody;
    public bool sproutMode;
    public float minSize, maxSize;

    private Rigidbody rb;
    private float timeElapsed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        transform.localScale *= Random.Range(minSize, maxSize);
        transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
    }

    private void FixedUpdate()
    {
        timeElapsed += Time.fixedDeltaTime;

        if (rb.velocity.sqrMagnitude < 0.1 && timeElapsed > 3)
        {
            if (deleteRigidbody)
            {
                Destroy(rb);
            }

            transform.position += Vector3.up * -0.0045f * transform.localScale.magnitude;
            Destroy(this);
        }
    }
}
