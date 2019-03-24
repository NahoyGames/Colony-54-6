using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float maxHealth;
    public int minDrops, maxDrops;

    public GameObject deathParticle;
    public GameObject dropObject;

    private float health;


    private void Start()
    {
        health = maxHealth;
    }

    public void Damage(float amount)
    {
        this.health -= amount;

        if (health <= 0)
        {
            Kill();
        }
    }


    public void Kill()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);


        int dropCount = Random.Range(minDrops, maxDrops);


        for (int i = 0; i < dropCount; i++)
        {
            Instantiate(dropObject);
        }

        Destroy(this.gameObject);
    }
}
