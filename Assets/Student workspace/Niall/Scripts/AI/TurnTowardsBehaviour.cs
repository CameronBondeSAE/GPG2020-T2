﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall 
{
    public class TurnTowardsBehaviour : SteeringBehaviourBase
    {

        public Transform FollowPos;
        public float force = 0.1f;
        private LineOfSight lineOfSight;
        private FindClosest findClosest;
        public bool playerfollow;
        public Nearby nearby;




        public void Update()
        {
            if (playerfollow)
            {
                FollowPos = findClosest.closestPlayer.transform;
            }

            if (FollowPos != null)
            {
                Vector3 targetDelta = FollowPos.position - transform.position;

                float angleDiff = Vector3.Angle(transform.forward, targetDelta);

                Vector3 cross = Vector3.Cross(transform.forward, targetDelta);

                rb.AddTorque(cross * (angleDiff * force * Time.deltaTime));
            }
        }
    }
}
