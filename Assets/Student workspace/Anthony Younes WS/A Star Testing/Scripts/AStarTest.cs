using UnityEngine;
using System.Collections.Generic;

namespace AnthonyY
{

    public class AStarTest : MonoBehaviour
    {
        public class Node //cost variables
        {
            public bool walkable;
            public Vector3 worldPosition;

            public int gCost;
            public int hCost;

            public int gridX;
            public int gridY;
            public Node parent;
            

            public Node(bool _walkable, Vector3 _worldPos, int _gridX,int _gridY)
            {
                walkable = _walkable;
                worldPosition = _worldPos;
                gridX = _gridX;
                gridY = _gridY;
            }
//calculating the lowest f cost for cheapest path
            public int fCost
            {
                get { return gCost + hCost; }
            }
            
            
        }
        
        //need a goal variable
        //start position
        private Node currentNode;
        public Vector2Int gridSize;
        public bool displayGrid;

        private int gridSizeX, gridSizeY;

        //lists of nodes to follow to get to the objective
        private Node[,] nodeArray;
        private float nodeDiameter;
        public float nodeRadius;

        private List<Node> openNodes; //nodes that have been visited but not been expanded

        public LayerMask unTouchableSurface; //mask for obstacles

        
        private void Awake()
        {
            nodeDiameter = nodeRadius * 2;
            gridSizeX = Mathf.RoundToInt(gridSize.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt(gridSize.y / nodeDiameter);
            nodeArray = new Node[gridSize.x, gridSize.y];
            CreateNodes(0,gridSize.x,0, gridSize.y);
            // CreateNodes(0,rd.bounds.min(gridSize.x - Vector3.right)
        }

        public int MaxSize
        {
            get { return gridSizeX * gridSizeY; }
        }

        /// <summary>
        /// Responsible for creating the grid and figuring out the goals and start position
        /// </summary>
        public void CreateNodes(int startX, int endX, int startY, int endY)
        {
            Vector3 worldBottomLeft =
                transform.position - Vector3.right * gridSize.x / 2 - Vector3.forward * gridSize.y / 2;
            
            for (int x = startX; x < endX; x++)
            {
                for (int y = startY; y < endY; y++)
                {
                    Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) +
                                         Vector3.forward * (y * nodeDiameter + nodeRadius);
                   
                    bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unTouchableSurface));
                    if (nodeArray[x, y] != null)
                    {
                        
                    }
                    else
                    {
                       
                    }


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
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;
                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;

                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
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
        public void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridSize.x, 1, gridSize.y));

            if (nodeArray != null && displayGrid)
            {
                foreach (Node n in nodeArray)
                {
                    Gizmos.color = n.walkable ? Color.white : Color.red;
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
                }
            }

        }
    }
}

    
    
