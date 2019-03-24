using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private float miningRange = 1000.0f;
    [SerializeField] private float damageMin, damageMax;

    [SerializeField] private Material laserMat;

    private LineRenderer lr;


    private void Start()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.material = laserMat;
        lr.endWidth = lr.startWidth = 0.1f;
    }


    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            lr.enabled = true;

            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, transform.forward, out hit, miningRange))
            {

                lr.SetPositions(new Vector3[] { this.transform.position + (Vector3.down * 5f), hit.point});

                Destructible d;
                if ((d = hit.collider.gameObject.GetComponent<Destructible>()) != null)
                {
                    d.Damage(Random.Range(damageMin, damageMax));

                    Debug.Log("Damaging!");
                }
            }
        }
        else
        {
            lr.enabled = false;
        }
    }
}
