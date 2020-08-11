using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Niall
{
    public class LineOfSight : MonoBehaviour
    {
        public Transform eyes;
        public Transform target;
        public float range;
        public bool haveLOS;

        void Update()
        {
            Los();
        }

        public void Los()
        {
            RaycastHit hit;
            Debug.DrawRay(eyes.position, eyes.forward * range, Color.red);
            if (Physics.Raycast(eyes.position, eyes.forward, out hit, range))
            {
                Debug.Log(this.name + " found Target! = " + hit.collider.name);
            }
            // TODO Only look at target when a clear line of sight is available (no objects between this and target.)
            //  RaycastHit hitt;
            //   Debug.DrawRay(eyes.position, target.position, Color.grey);
            //   if (Physics.Raycast(eyes.position, target.position, out hitt, range))
            //   {
            //       if (hitt.collider != target)
            //       {
            //           haveLOS = false;
            //       }
            //      else
            //      {
            //          haveLOS = true;
            //      }
        }
    }
}