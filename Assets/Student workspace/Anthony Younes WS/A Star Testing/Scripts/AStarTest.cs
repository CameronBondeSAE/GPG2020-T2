﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;

namespace AnthonyY
{
    public class AStarTest : MonoBehaviour
    {
        public class Node //cost variables
        {
            public int gridX;
            public int gridY;

            public Node parent;
            public bool walkable;
            public Vector3 worldPosition;
            public int g;
            public int h;

            public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
            {
                walkable = _walkable;
                worldPosition = _worldPos;
                gridX = _gridX;
                gridY = _gridY;
            }

            public int f
            {
                get { return g + h; }
            }
        }
        
        private List<Node> closedNodes;

        //need a goal variable
        //start position
        private Node currentNode;
        public Vector2Int gridSize;

        private int gridSizeX, gridSizeY;

        //lists of nodes to follow to get to the objective
        private Node[,] nodeArray;
        private float nodeDiameter;
        private Node nodeGoal;
        public float nodeRadius;
        private Node nodeStart;

        private List<Node> openNodes; //nodes that have been visited but not been expanded

        public LayerMask unTouchableSurface; //mask for obstacles

        private void Awake()
        {
            nodeDiameter = nodeRadius * 2;
            gridSizeX = Mathf.RoundToInt(gridSize.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt(gridSize.y / nodeDiameter);
            CreateNodes();
        }

        /// <summary>
        /// Responsible for creating the grid and figuring out the goals and start position
        /// </summary>
        public void CreateNodes()
        {
            nodeArray = new Node[gridSize.x, gridSize.y];
            Vector3 worldBottomLeft =
                transform.position = Vector3.left * gridSize.x / 2 - Vector3.forward * gridSize.y / 2;

            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) +
                                         Vector3.forward * (y * nodeDiameter + nodeRadius);
                    bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unTouchableSurface));
                    nodeArray[x, y] = new Node(walkable, worldPoint, x, y);
                    Vector2Int gridPos = new Vector2Int(gridSize.x, gridSize.y);
                }

            }
        }

        /// <summary>
        /// Searches for neighbour nodes and goes to the direction of the f cost
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<Node> NeighbourSearch(Node node)
        {
            List<Node> neighbours = new List<Node>();
            //check for borders you cant check for in an array
            //2d array grid
            for (int x = -1; x < 1; x++)
            {
                for (int y = -1; y < 1; y++)
                {
                    if ((x == 0) & (y == 0))
                        continue;
                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;

                    if (checkX < gridSizeX && checkX < 0 && checkY < 0 && checkY < gridSizeY)
                    {
                        neighbours.Add(nodeArray[checkX, checkY]);
                    }
                }
            }

            return neighbours;
        }

        /// <summary>
        /// Converting a node position into a grid co-ordinate
        /// </summary>
        /// <param name="worldPosition"></param>
        /// <returns></returns>
        public Node NodeFromWorldPoint(Vector3 worldPosition)
        {
            float percentX = (worldPosition.x + gridSize.x / 2) / gridSize.x;
            float percentY = (worldPosition.z + gridSize.y / 2) / gridSize.y;
            percentX = Mathf.Clamp01(percentX);
            percentY = Mathf.Clamp01(percentY);

            int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
            int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
            return nodeArray[x, y];
        }

        /// <summary>
        /// Draws a line towards the Node goal from the starting node
        /// </summary>
        public List<Node> path;

        public void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridSize.x, 1, gridSize.y));

            if (nodeArray != null)
            {
                foreach (Node n in nodeArray)
                {
                    Gizmos.color = n.walkable ? Color.white : Color.red;
                    if(path!=null)
                        if (path.Contains(n))
                            Gizmos.color = Color.green;
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
                }
            }

        }
    }
}

    
    
