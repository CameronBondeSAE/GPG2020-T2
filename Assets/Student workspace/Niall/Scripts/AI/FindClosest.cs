using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;

namespace Niall
{
    public class FindClosest : MonoBehaviour
    {

        private float distToClosestPlayer;

        public void Awake()
        {
            distToClosestPlayer = Mathf.Infinity;
        }
        public void Update()
        {
            FindClosestPlayer();
        }

        public void FindClosestPlayer()
        {
        
            
            
        }
    }
}