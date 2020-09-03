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
        public PlayerControllerTopDown closestPlayer;
        private PlayerControllerTopDown[] players;
        public float playerDist;
        public float closestPlayerDist = 10000f;

        private void Start()
        {
            players = FindObjectsOfType<PlayerControllerTopDown>();
        }

        public void Update()
        {
            

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