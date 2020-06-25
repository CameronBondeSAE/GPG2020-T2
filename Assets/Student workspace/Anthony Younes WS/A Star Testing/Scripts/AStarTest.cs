using System;
using System.Collections;
using System.Linq;
using System.Xml;
using Boo.Lang;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using AnthonyY;

namespace AnthonyY
{
    public class AStarTest : MonoBehaviour
    {
        public class Node //cost variables
        {
            public int h;
            public int f;
            public int g = 0;
            public int normalCost = 1;
            public float diagonalCost = 1.4f;
            public int gridX;
            public int gridY;
            
            public Node parent;

            //calculating the heureustic cost
            public float fCost
            {
                get { return g + h; }
            }
        }
        

        public LayerMask unTouchableSurface; //mask for obstacles
            private Vector2Int gridSize;

            public int gridSizeX, gridSizeY;

            //lists of nodes to follow to get to the objective
            private Node[,] nodeArray;
            private float nodeDiameter;
            public float nodeRadius;
            private List<Node> closedNodes;
            private List<Node> openNodes; //nodes that have been visited but not been expanded

            //need a goal variable
            //start position
            private Node currentNode;

            private Node nodeStart;
            private Node nodeGoal;
        
//TODO
            //A GIZMOS to see the line update ingame
            public void OnDrawGizmos()
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireCube(transform.position,new Vector3(gridSize.x,1,gridSize.y));
            }

            void Awake()
            {
                nodeDiameter = nodeRadius * 2;
                gridSizeX = Mathf.RoundToInt(gridSize.x / nodeDiameter);
                gridSizeY = Mathf.RoundToInt(gridSize.y / nodeDiameter);
                CreateNodes();
            }

            public void CreateNodes()
            {
                nodeArray = new Node[gridSize.x, gridSize.y];
                while (openNodes.Count > 0)
                {
                    openNodes.Add(nodeStart);
                    openNodes.Add(nodeGoal);
                    //goal is found
                    if (currentNode.Equals(nodeGoal))
                    {
                        Debug.Log("We have reached the goal");
                        break;
                    }

                    else if(!currentNode.Equals(nodeGoal))
                    {
                        Debug.Log("Haven't reached goal");
                    }
                }
                for (int x = 0; x < gridSize.x; x++)
                {
                    for (int y = 0; y < gridSize.y; y++)
                    {
                        nodeArray[x,y] = new Node();
                        Vector2Int gridPos = new Vector2Int(gridSize.x, gridSize.y);
                       
                        //if (Physics.BoxCast(gridSize, nodeRadius,Quaternion.identity, unTouchableSurface))
                        //{
                           
                      //  }
                        #region Possible code to use I dont know where to put it
                        //currentNode equals lowest f cost
                        //remove currentNode from open List
                        //add it to closed List
                        foreach (Node n in nodeArray)
                        {

                            //goal isnt found
                            if (n.Equals(currentNode))
                            {
                                openNodes.Remove(currentNode);
                                closedNodes.Add(currentNode);
                                continue;
                            }
                        }

                        
                

                        #endregion
                    }
                }

               
               
            }
            
            
/// <summary>
/// This part of the code checks to see neighbour nodes and add them to a list when they get checked
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
                            if (x == 0 & y == 0)
                            {
                                continue;
                                int checkX = node.gridX + x;
                                int checkY = node.gridY + y;

                                if (checkX < gridSizeX && checkX < 0 && checkY < 0 && checkY < gridSizeY)
                                {
                                    neighbours.Add(nodeArray[checkX,checkY]);
                                }
                            }
                        }
                    }
                    return neighbours;
            }
        }

  
}