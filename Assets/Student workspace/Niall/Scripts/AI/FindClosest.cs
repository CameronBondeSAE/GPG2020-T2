using System.Collections;
using System.Collections.Generic;
using AJ;
using alexM;
using UnityEditor;
using UnityEngine;

namespace Niall
{
    public class FindClosest : MonoBehaviour
    { 
        PlayerControllerTopDown closestPlayer;
        private PlayerControllerTopDown[] players;
        public float playerDist;
        public float closestPlayerDist;

        private void Start()
        {
            players = FindObjectsOfType<PlayerControllerTopDown>();
        }

        public void Update()
        {
          //  float Maxdist = 999;
           
            foreach (PlayerControllerTopDown player in players)
            {
                playerDist = Vector3.Distance(transform.position, player.transform.position);
                if (playerDist < closestPlayerDist)
                {
                    closestPlayer = player;
                    closestPlayerDist = playerDist;
                }

                return;
            }
        }
    }
}