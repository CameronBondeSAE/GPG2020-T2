using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using Niall;
using UnityEngine;

namespace AnthonyY
{
    public class Pathfinding : MonoBehaviour
    {
        public AStarTest grid;
        public Transform seeker, target;

        private void Awake()
        {
            grid = GetComponent<AStarTest>();
        }

        private void Update()
        {
            FindPath(seeker.position,target.position);
        }

        void FindPath(Vector3 startPos, Vector3 targetPos)
        {
            AStarTest.Node startNode = grid.NodeFromWorldPoint(startPos);
            AStarTest.Node targetNode = grid.NodeFromWorldPoint(targetPos);
            
            List<AStarTest.Node> openSet = new List<AStarTest.Node>();
            //A list that is used to prevent duplicates from being inserted
            HashSet<AStarTest.Node> closedSet = new HashSet<AStarTest.Node>();
            
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                AStarTest.Node currentNode = openSet[0];
                for (int i = 1; i < openSet.Count; i++)
                {
                    //setting the current node to the lowest cost node
                    //this also can be optimised
                    if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                    {
                        currentNode = openSet[i];
                    }
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);
                if (currentNode == targetNode)
                {
                    RetracePath(startNode,targetNode);
                    return;
                }
                
                //checking if you can walk to the neighbour
                foreach (AStarTest.Node neighbour in grid.NeighbourSearch(currentNode))
                {
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }
                     //calculating the new GCost
                    int NewMovementCostToNeighBour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    if (NewMovementCostToNeighBour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = NewMovementCostToNeighBour;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }
                }
            }
        }
/// <summary>
/// Retracing our steps to go back to the start Node
/// </summary>
/// <param name="startNode"></param>
/// <param name="endNode"></param>
        void RetracePath(AStarTest.Node startNode, AStarTest.Node endNode)
        {
            List<AStarTest.Node> path = new List<AStarTest.Node>();
            AStarTest.Node currentNode = endNode;
            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }
            path.Reverse();

            grid.path = path;

        }

        int GetDistance(AStarTest.Node nodeA, AStarTest.Node nodeB)
        {
            int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
            int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

            if (dstX > dstY)
                //the equation in full effect
                return 14 * dstY + 10 * (dstX - dstY);
                return 14 * dstX + 10 * (dstY - dstX);
            
        }
    }
}


