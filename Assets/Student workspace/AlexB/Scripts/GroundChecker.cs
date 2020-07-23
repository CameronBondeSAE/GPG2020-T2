using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace alexM
{
    public class GroundChecker : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            
                Debug.Log("Touching:" + other.gameObject.name);
            
        }
    }

}