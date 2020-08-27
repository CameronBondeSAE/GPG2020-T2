using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Niall
{
    public class LineOfSight : MonoBehaviour
    {
        public Transform eyes;
        public List<Transform> targets = new List<Transform>();
        public Transform _target;
        public float range;
        public bool haveLOS;
        public UnityEvent<bool> changedLOS;

        void Update()
        {
            if (targets != null)
            {
                Los();
            }
            
            Vector3 targetDir = _target.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);

            if (angle < 3.0f)
            {
                print("Bang");
            }
        }

        public bool Los()
        {
            haveLOS = false;

            foreach (Transform target in targets)
            {
                // RaycastHit hit;
                // Debug.DrawRay(eyes.position, eyes.forward * range, Color.white);
                // if (Physics.Raycast(eyes.position, eyes.forward, out hit, range))
                // {
                // Debug.Log(this.name + " found Target! = " + hit.collider.name);
                // }

                RaycastHit hitt;

                if (Physics.Linecast(eyes.position, target.position, out hitt))
                {
                    if (hitt.transform.root == target) // This will check the main Transform against the target transforms
                    {
                        haveLOS = true;
                        _target = target.transform;
                        Debug.DrawLine(eyes.position, hitt.point, Color.red);
                    }
                }
            }
            return haveLOS;


        }
    }
}