using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using Mirror.Examples;
using UnityEngine;


public class NolanUnit : MonoBehaviour
{
    public void Start()
    {
        GetComponent<HealthComponent>().deathEvent.AddListener(Dead);
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