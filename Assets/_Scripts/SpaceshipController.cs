using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceshipController : MonoBehaviour
{


    [SerializeField] private string rollInput;
    [SerializeField] private string yawInput;
    [SerializeField] private string pitchInput;
    [SerializeField] private string thurstInput;


    [SerializeField] private float rollSpeed;
    [SerializeField] private float yawSpeed;
    [SerializeField] private float pitchSpeed;

    [SerializeField] private float minThurst, maxThurst;


    private Rigidbody rb;

    private Vector3 vel;
    private float thurst;
    private float Thurst
    {
        get
        {
            return thurst;
        }

        set
        {
            thurst = Mathf.Clamp(value, minThurst, maxThurst);
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float roll = -Input.GetAxis(rollInput) * rollSpeed;
        float yaw = Input.GetAxis(yawInput) * yawSpeed;
        float pitch = Input.GetAxis(pitchInput) * pitchSpeed;
        Thurst += Input.GetAxis(thurstInput);


        vel.z = yaw;
        vel.y = roll - (yaw / 200  * yawSpeed);
        vel.x = pitch;

        vel.y += (((transform.localEulerAngles.y % 360) - 180) * 0.5f);

        rb.AddRelativeTorque(vel * Time.deltaTime);

        rb.AddRelativeForce(Vector3.up * Thurst * Time.deltaTime, ForceMode.Impulse);

        Debug.Log(transform.localEulerAngles.z % 360);
    }

}
