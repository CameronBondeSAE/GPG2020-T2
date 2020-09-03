using System;
using System.Collections;
using System.Collections.Generic;
using Niall;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 2;
    private bool OnwardPeasent = false;
    public bool los;


    public void Start()
    {
        los = GetComponent<LineOfSight>().Los();
    }

    public void Update()
    {
        if (los)
        {
            OnwardPeasent = true;
        }
        if (OnwardPeasent)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }
}
