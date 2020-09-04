using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall 
{
    public class TurnTowardsBehaviour : SteeringBehaviourBase
    {

        public Transform FollowPos = null;
        public float force = 0.1f;
        private LineOfSight lineOfSight;
        public bool playerfollow;
        public Nearby nearby;

        private void Start()
        {
            nearby = GetComponent<Nearby>();
        }


        public void FixedUpdate()
        {
            if (playerfollow)
            {
                FollowPos = nearby.GetClosest()?.transform;
            }

            if (nearby.players.Count <= 0)
            {
                FollowPos = null;
            }

            if (/*lineOfSight.Los() &&*/ FollowPos != null)
            {
                Vector3 targetDelta = FollowPos.position - transform.position;

                float angleDiff = Vector3.Angle(transform.forward, targetDelta);

                Vector3 cross = Vector3.Cross(transform.forward, targetDelta);

                GetComponent<Rigidbody>().AddTorque(cross * (angleDiff * (force * Time.deltaTime)));
            }
        }
    }
}
