using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Mirror;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AnthonyY
{
    [CustomEditor(typeof(AvoidBehaviour))]
    public class AvoidBehaviourEditor : Editor
    {
        void OnSceneGUI()
        {
            Handles.color = Color.red;
            if (target != null)
            {
                AvoidBehaviour avoidBehaviour = (AvoidBehaviour) target;
                Handles.DrawSolidArc(avoidBehaviour.transform.position, avoidBehaviour.transform.forward,
                    avoidBehaviour.transform.forward, avoidBehaviour.turnSpeed, avoidBehaviour.distance);
                Handles.color = Color.white;
                avoidBehaviour.distance = (float)Handles.ScaleValueHandle(avoidBehaviour.distance, avoidBehaviour.transform.position + avoidBehaviour.transform.forward * avoidBehaviour.distance, avoidBehaviour.transform.rotation, 1, Handles.ConeHandleCap, 1);
            }
        }
    }

    public class AvoidBehaviour : NetworkBehaviour
        {
            public Rigidbody rb;
            private Transform t;
            public float distance;
            public float turnSpeed;
            public float direction;
            RaycastHit hit;
            private bool raycast;

            void Start()
            {
                t = transform;
            }

            private void FixedUpdate()
            {
                if (t != null) raycast = Physics.Raycast(t.position, t.forward, out hit, distance);
                if (raycast)
                {
                     rb?.AddTorque(0, turnSpeed * direction, 0);
                    // Debug.DrawLine(t.position, t.forward,gameObject.name,distance,Color.green);
                }


                Mathf.PerlinNoise(turnSpeed, distance);
            }

          void OnDrawGizmos()
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(hit.point, new Vector3(0.1f,0.1f,0.1f));
            }

        }
    }

