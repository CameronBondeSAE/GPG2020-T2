using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall 
{
    public class TurnTowardsBehaviour : MonoBehaviour
    {

        public Transform FollowPos;
        public float force = 0.1f;
        private LineOfSight lineOfSight;


        public void Start()
        {
            lineOfSight = GetComponent<LineOfSight>();

        }

        public void Update()
        {
            
            if (lineOfSight.haveLOS && FollowPos != null)
            {
                Vector3 targetDelta = FollowPos.position - transform.position;

                float angleDiff = Vector3.Angle(transform.forward, targetDelta);

                Vector3 cross = Vector3.Cross(transform.forward, targetDelta);

                GetComponent<Rigidbody>().AddTorque(cross * (angleDiff * force));
            }
        }
    }
}
