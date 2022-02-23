using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // To destroy the projectile after a certain amount of time
    void Start()
    {
        Destroy(gameObject, 3);
    }

    private void OnCollissionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Destroy(collision.gameObject, 1);
        }
        Destroy(gameObject);
    }
}