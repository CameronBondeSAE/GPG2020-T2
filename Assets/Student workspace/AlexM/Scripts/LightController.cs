using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
     public bool toggleState;
    [HideInInspector] public float intensity;

    [HideInInspector] public Light light;

    void Awake()
    {
        light = gameObject.GetComponent<Light>();
        //toggleState = gameObject.activeSelf;
        intensity = light.intensity;
    }

    private void Update()
    {
        if (toggleState)
        {
           //Toggle Off
           light.intensity = intensity;

        }
        else
        {
            //light.gameObject.SetActive(true);
            light.intensity = 0;
        }
    }

    public void TurnOn()
    {
        toggleState = true;
    }

    public void TurnOff()
    {
        toggleState = false;
    }


    public void Toggle()
    {
        if (toggleState)
        {
            toggleState = false;
        }else if (!toggleState)
        {
            toggleState = true;
        }
    }
   
}
