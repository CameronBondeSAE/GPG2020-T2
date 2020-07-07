using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class Node
    {
        public bool walkable;
        public Vector3 worldposition;
        public int gridX;
        public int gridY;

        public int gCost;
        public int hCost;
        public Node parent;

        public int fCost
        {
            get { return gCost + hCost; }
        }

        public Node(bool _walkable, Vector3 _worldposition, int _gridX, int _gridY)
        {
            walkable = _walkable;
            worldposition = _worldposition;
            gridX = _gridX;
            gridY = _gridY;
        }
      
      
    }
}