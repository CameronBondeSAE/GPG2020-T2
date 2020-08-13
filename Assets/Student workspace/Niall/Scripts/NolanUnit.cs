using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using Mirror.Examples;
using UnityEngine;
using Niall;


public class NolanUnit : MonoBehaviour
{

    public Component lineOfSight;
    public Rigidbody rb;
    public void Start()
    {
        GetComponent<HealthComponent>().deathEvent.AddListener(Dead);
        lineOfSight = GetComponent<LineOfSight>();
        rb = GetComponent<Rigidbody>();
    }


    public void Update()
    {
        
    }

    public void Dead(HealthComponent arg0)
    {
        Destroy(gameObject);
    }


    public void OnDestroy()
    {
        GetComponent<HealthComponent>().deathEvent.RemoveListener(Dead);
    }
}