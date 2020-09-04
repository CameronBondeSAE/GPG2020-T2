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
            lineofSight.singleTarget = nearby.GetClosest()?.transform;
            if (lineofSight.singleTarget)
            {
                nearby.GetClosest().RB.AddForce(lineofSight.singleTarget.position * (suctionPower * (1 / Vector3.Distance(transform.position, lineofSight.singleTarget.position))), ForceMode.Acceleration);
            }
            
        }
    }
}