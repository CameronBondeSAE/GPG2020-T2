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
    public bool invert;
    public DirectionOfSpin spinDir = DirectionOfSpin.Horizontal;

    public enum DirectionOfSpin
    {
        Horizontal,
        Vertical
    }
    
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
        switch (spinDir)
        {
            case DirectionOfSpin.Horizontal:
                if (!invert)
                {
                    transform.Rotate(0,(1*speed) * Time.deltaTime,0);    
                }
                else
                {
                    transform.Rotate(0,(-1*speed) * Time.deltaTime,0);
                }
                break;
            case DirectionOfSpin.Vertical:
                if (!invert)
                {
                    transform.Rotate(0,0,(-1*speed) * Time.deltaTime);    
                }
                else
                {
                    transform.Rotate(0,0,(-1*speed) * Time.deltaTime);
                }
                break;
        }
        
        
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
