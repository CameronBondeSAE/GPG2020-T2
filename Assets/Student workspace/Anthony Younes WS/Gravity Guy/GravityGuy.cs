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

        void Start()
        {
            nearby.PlayerListUpdated += SuckEmIn; 
        }
        private void Update()
        {
           SuckEmIn();
            
        }
        

        private void SuckEmIn()
        {
            playerDist = transform.position - nearby.GetClosest().transform.position;
            nearby.GetClosest().RB.AddForce( playerDist * suctionPower * (1 / Vector3.Distance(transform.position, nearby.GetClosest().transform.position)), ForceMode.Impulse);
        }
    }


}