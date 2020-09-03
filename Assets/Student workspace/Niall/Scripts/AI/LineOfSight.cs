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
        private Transform _target;
        public float range;
        public bool haveLOS;
        public UnityEvent<bool> changedLOS;
        public float Degrees = 5.0f;
        public Nearby nearby;




        void Update()
        {
            if (targets != null)
            {
                Los();
            }
            

        }

        public bool Los()
        {
            haveLOS = false;

            foreach (Transform target in targets)
            {
                _target = target.transform;
                
                RaycastHit hitt;
                
                Vector3 targetDir = _target.position - transform.position;
                float angle = Vector3.Angle(targetDir, transform.forward);
                
                if (Physics.Linecast(eyes.position, target.position, out hitt))
                {
                    if (angle < Degrees) 
                    {
                        haveLOS = true;
                        
                        Debug.DrawLine(eyes.position, hitt.point, Color.red);
                    }
                }
            }
            return haveLOS;


        }
    }
}