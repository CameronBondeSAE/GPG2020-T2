using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AnthonyY
{
    public class AvoidBehaviour : NetworkBehaviour
    {
        public Rigidbody rb;
        private Transform t;
        public float distance;
        public float turnSpeed;
        void Start()
        {
            t = transform;
        }

        private void FixedUpdate()
        {
            RaycastHit hit;


            if (Physics.Raycast(t.position, t.forward, out hit, distance))
            {
                rb.AddTorque(0, turnSpeed, 0);

            }

            Debug.DrawRay(t.position, t.forward,Color.green);
            Mathf.PerlinNoise(turnSpeed, distance);
        }


    } 
}

