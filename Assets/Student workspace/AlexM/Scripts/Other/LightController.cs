using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace alexM
{
    public class LightController : MonoBehaviour
    {
        public bool toggleState;
        [HideInInspector] public float intensity;

        [HideInInspector] public Light light;

        public UnityEvent turnedOnEvent, turnedOffEvent;

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
                TurnOn();
            }
            else
            {
                TurnOff();
            }
        }

        public void TurnOn()
        {
            light.intensity = intensity;
            toggleState = true;
            turnedOnEvent.Invoke();
        }

        public void TurnOff()
        {
            light.intensity = 0;
            toggleState = false;
            turnedOffEvent.Invoke();
        }


        public void Toggle()
        {
            if (toggleState)
            {
                TurnOff();
                toggleState = false;
            }
            else if (!toggleState)
            {
                TurnOn();
                toggleState = true;
            }
        }

    }
}
