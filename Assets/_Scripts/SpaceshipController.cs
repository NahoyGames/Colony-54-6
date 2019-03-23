using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceshipController : MonoBehaviour
{


    [SerializeField] private string rollInput;
    [SerializeField] private string yawInput;
    [SerializeField] private string pitchInput;


    [SerializeField] private float rollSpeed;
    [SerializeField] private float yawSpeed;
    [SerializeField] private float pitchSpeed;

    private Rigidbody rb;

    private Vector3 vel;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float roll = -Input.GetAxis(rollInput) * rollSpeed;
        float yaw = Input.GetAxis(yawInput) * yawSpeed;
        float pitch = Input.GetAxis(pitchInput) * pitchSpeed;

        vel.z = yaw;
        vel.y = roll - (yaw / 2  * yawSpeed);
        vel.x = pitch;

        rb.AddRelativeTorque(vel);

        rb.AddRelativeForce(Vector3.up * 2, ForceMode.Impulse);

        Debug.Log(transform.localEulerAngles.z);
    }

}
