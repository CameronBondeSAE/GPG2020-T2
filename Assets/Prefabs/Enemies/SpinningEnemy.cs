using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

public class SpinningEnemy : MonoBehaviour
{
    [Header("Settings"), Tooltip("Tick this and it will set the object to a trigger. When it touches something with a HealthComponent it will kill it.")]
    public bool kills;
    public float speed;


    private void Start()
    {
        Collider col = GetComponent<Collider>();
        if (kills)
        {
            col.isTrigger = true;
        }
        else
        {
            col.isTrigger = false;
        }
    }

    private void FixedUpdate()
    {
        Spin();
    }

    public void Spin()
    {
        transform.Rotate(0,(1*speed) * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponentInParent<HealthComponent>())
        {
            other.GetComponentInParent<HealthComponent>().Death();
            Debug.Log("You Ded.");
            
        }
    }
    
    
}
