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
        public Nearby nearbyPlayers;
        Vector3 playerDist;
        public float suctionPower = 1;

        private void Update()
        {
            if(GetComponentInChildren<Nearby>())
            {
                SuckEmIn();
            }
        }

        public void SuckEmIn()
        {
            foreach ( PlayerControllerTopDown player in nearbyPlayers.players)
            {
                playerDist = transform.position - player.transform.position;
                player.RB.AddForce(playerDist * suctionPower * (1 / Vector3.Distance(transform.position, player.transform.position)), ForceMode.Impulse);
            }
        }
    }


}