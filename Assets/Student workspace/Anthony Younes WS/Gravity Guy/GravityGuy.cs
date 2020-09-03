using System;
using System.Collections;
using System.Collections.Generic;
using alexM;
using Mirror.Examples.Pong;
using Niall;
using UnityEngine;

namespace AnthonyY
{
    public class GravityGuy : MonoBehaviour
    {
        public Nearby nearby;
        private Vector3 playerDist;
        public float suctionPower = 1;
        public LineOfSight lineofSight;
        private void Update()
        {
           SuckEmIn();
        }


        private void SuckEmIn()
        {
            lineofSight.singleTarget = nearby.GetClosest().transform;
            var lineofSighttransform = lineofSight.singleTarget.transform;
            if (lineofSight.Los())
            {
                nearby.GetClosest().RB.AddForce(lineofSighttransform.position * (-suctionPower * (1 / Vector3.Distance(transform.position, lineofSighttransform.position))), ForceMode.Impulse);
            }
            
        }
    }
}