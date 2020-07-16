using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace Niall
{
    public class DestroyRogueObject : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            other.GetComponent<HealthComponent>().Death();
        }
    }
}