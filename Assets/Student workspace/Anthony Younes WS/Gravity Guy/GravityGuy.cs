using System;
using System.Collections;
using System.Collections.Generic;
using alexM;
using Mirror.Examples.Pong;
using UnityEngine;

namespace AnthonyY
{
    public class GravityGuy : MonoBehaviour
    {
        public Nearby nearby;
        public Vector3 playerDist;
        public float suctionPower = 1;
        private void Update()
        {
           SuckEmIn();
        }
        

        private void SuckEmIn()
        {
            if (!(nearby is null))
            {
                playerDist = nearby.GetClosest().transform.position;
                if (nearby.GetClosest() != null)
                {
                    nearby.GetClosest().RB
                        .AddForce(playerDist * (suctionPower * (1 / Vector3.Distance(transform.position,
                            nearby.GetClosest().transform.position))), ForceMode.Impulse);
                }
            }
        }
    }


}