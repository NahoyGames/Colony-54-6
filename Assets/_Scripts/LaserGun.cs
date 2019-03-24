using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private float miningRange = 1000.0f;
    [SerializeField] private float damageMin, damageMax;
    [SerializeField] private float hitSpeed;

    [SerializeField] private Material laserMat;
    [SerializeField] private Transform hand;

    private LineRenderer lr;

    private float timer;


    private void Start()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.material = laserMat;
        lr.endWidth = lr.startWidth = 0.02f;
    }


    private void Update()
    {

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {

            lr.enabled = true;

            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, transform.forward, out hit, miningRange))
            {

                lr.SetPositions(new Vector3[] { hand.position, hit.point});

                if (timer >= hitSpeed)
                {
                    Destructible d;
                    if ((d = hit.collider.gameObject.GetComponent<Destructible>()) != null)
                    {
                        d.Damage(Random.Range(damageMin, damageMax), hit);

                        Debug.Log("Damaging!");
                    }

                    timer = 0;
                }
            }
            else
            {
                lr.SetPositions(new Vector3[] { hand.position, transform.forward * 1000 });
            }
        }
        else
        {
            lr.enabled = false;
        }
    }
}
