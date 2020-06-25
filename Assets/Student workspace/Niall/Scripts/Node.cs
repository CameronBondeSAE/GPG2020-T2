using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class Node
    {
        public bool walkable;
        public Vector3 worldposition;

        public Node(bool _walkable, Vector3 _worldposition)
        {
            walkable = _walkable;
            worldposition = _worldposition;
        }
    }
}