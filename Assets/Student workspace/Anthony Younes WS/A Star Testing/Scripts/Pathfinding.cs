using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AnthonyY;
using Niall;
using ReGoap.Planner;
using UnityEngine;

namespace AnthonyY
{
    public class Pathfinding : MonoBehaviour
    {
        private PathRequestManager _requestManager;
        public AStarTest grid;

        private void Awake()
        {
            _requestManager = GetComponent<PathRequestManager>();
            grid = GetComponent<AStarTest>();
        }

//start the find path coroutine
       public void StartFindPath(Vector3 startPos, Vector3 targetPos)
        {
            StartCoroutine(FindPath(startPos, targetPos));
        }
        IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
        { 
           
            AStarTest.Node startNode = grid.NodeFromWorldPoint(startPos);
            AStarTest.Node targetNode = grid.NodeFromWorldPoint(targetPos);
            Vector3[] waypoints = new Vector3[0];
            bool pathSuccess = false;

            if (startNode.walkable && targetNode.walkable)
            {
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
                        if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost &&
                            openSet[i].hCost < currentNode.hCost)
                        {
                            currentNode = openSet[i];
                        }
                    }

                    openSet.Remove(currentNode);
                    closedSet.Add(currentNode);
                    if (currentNode == targetNode)
                    {
                        pathSuccess = true;
                        break;
                    }

                    //checking if you can walk to the neighbour
                    foreach (AStarTest.Node neighbour in grid.NeighbourSearch(currentNode))
                    {
                        if (!neighbour.walkable || closedSet.Contains(neighbour))
                        {
                            continue;
                        }

                        //calculating the new GCost
                        int newMovementCostToNeighBour = currentNode.gCost + GetDistance(currentNode, neighbour);
                        if (newMovementCostToNeighBour < neighbour.gCost || !openSet.Contains(neighbour))
                        {
                            neighbour.gCost = newMovementCostToNeighBour;
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
            yield return null;
            if (pathSuccess)
            {
                waypoints = RetracePath(startNode, targetNode);
            }
            _requestManager.FinishedProccessingPath(waypoints, pathSuccess);
        }
/// <summary>
/// Retracing our steps to go back to the start Node
/// </summary>
/// <param name="startNode"></param>
/// <param name="endNode"></param>
        Vector3[] RetracePath(AStarTest.Node startNode, AStarTest.Node endNode)
        {
            List<AStarTest.Node> path = new List<AStarTest.Node>();
            AStarTest.Node currentNode = endNode;
            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }

            Vector3[] waypoints = Simplifypath(path);
            Array.Reverse(waypoints);
            return waypoints;



        }
Vector3[] Simplifypath(List<AStarTest.Node> path)
{
    List<Vector3> waypoints = new List<Vector3>();
   //store the direction of the last 2 nodes
    Vector2 directionOld = Vector2.zero; 
    
    // a for loop used to insert the old directions of the nodes and implement the new ones
    for (int i = 1; i < path.Count; i ++) {
        Vector2 directionNew = new Vector2(path[i-1].gridX - path[i].gridX,path[i-1].gridY - path[i].gridY);
        if (directionNew != directionOld) {
            //add to the waypoint list because it has changed direction
            waypoints.Add(path[i-1].worldPosition);
        }
        //then we set the old node to the new nodes
        directionOld = directionNew;
    }
    return waypoints.ToArray();
}

        int GetDistance(AStarTest.Node nodeA, AStarTest.Node nodeB)
        {
            int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
            int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);
            
            //14 is the diagonal cost for the pathfinding

            if (dstX > dstY)
                //the equation in full effect
                return 14 * dstY + 10 * (dstX - dstY);
                return 14 * dstX + 10 * (dstY - dstX);
            
        }
    }
}


