using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float size = 1f;
    public float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(size, size, size);
        GetComponent<NavMeshAgent>().speed *= speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            health -= other.transform.parent.GetComponent<Raygun>().damage;
        }
    }
}
