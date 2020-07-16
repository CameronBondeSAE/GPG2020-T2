using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class DestroyRogueObject : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
          //  other.GetComponent<NolanUnit>().Dead();
        }
    }
}