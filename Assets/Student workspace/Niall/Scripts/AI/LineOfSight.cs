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
        public float range;
        public bool haveLOS;
        public UnityEvent<bool> changedLOS;

        void Update()
        {
          if (targets != null)
          {Los();}
        }

        public void Los()
        {
            foreach (Transform target in targets)
            {


                RaycastHit hit;
                Debug.DrawRay(eyes.position, eyes.forward * range, Color.red);
                if (Physics.Raycast(eyes.position, eyes.forward, out hit, range))
                {
                    Debug.Log(this.name + " found Target! = " + hit.collider.name);
                }

                //  TODO Only look at target when a clear line of sight is available (no objects between this and target.)
                RaycastHit hitt;
                Debug.DrawLine(eyes.position, target.position, Color.white);
                if (Physics.Linecast(eyes.position, target.position, out hitt))
                {
                    if (hitt.collider != target.GetComponent<Collider>())
                    {
                        haveLOS = false;
                    }
                    else
                    {
                        haveLOS = true;
                    }
                }
            }
        }
    }
}