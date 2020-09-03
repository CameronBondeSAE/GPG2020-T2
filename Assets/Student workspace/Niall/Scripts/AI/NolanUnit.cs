using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using Mirror.Examples;
using UnityEngine;
using Niall;


public class NolanUnit : MonoBehaviour
{
    public float speed = 5f;

    public void Start()
    {
        GetComponent<HealthComponent>()?.deathEvent.AddListener(Dead);
    }


    public void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    public void Dead(HealthComponent arg0)
    {
        Destroy(gameObject);
    }


    public void OnDestroy()
    {
        GetComponent<HealthComponent>()?.deathEvent.RemoveListener(Dead);
    }
}