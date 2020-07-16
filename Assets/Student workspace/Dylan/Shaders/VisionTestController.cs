﻿using System;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Student_workspace.Dylan.Shaders
{
    public class VisionTestController : MonoBehaviour
    {
        [SerializeField] private bool isActive;
        [SerializeField] private float visionAbilityDuration;
        public float maxVisionAbilityDuration;
        public static event Action visionActivation;

        public void FixedUpdate()
        {
            if (InputSystem.GetDevice<Keyboard>().spaceKey.isPressed)
            {
                VisionAbility();
            }

            if (visionAbilityDuration > 0)
            {
                visionAbilityDuration -= Time.deltaTime;
            }
            
            if(visionAbilityDuration < 0)
            {
                visionAbilityDuration = 0;
                CallEvent();
                isActive = false;
            }
        }

        public void VisionAbility()
        {
            if (!isActive)
            {
                isActive = true;
                visionAbilityDuration = maxVisionAbilityDuration;
                CallEvent();
            }
        }

        public void CallEvent()
        {
            visionActivation?.Invoke();
        }
    }
}