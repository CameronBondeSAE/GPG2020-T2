using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class NodeGrid : MonoBehaviour
    {
        public Transform player;

        //  public List<Node> ONodes = new List<Node>();
        public LayerMask unwalkableMask;
        public Vector2 gridWorldSize;
        public float nodeRadius;
        public Node[,] grid;

        private int gridSizeX;
        private int gridSizeY;
        private float nodeD;

        public void Start()
        {
            nodeD = nodeRadius * 2;
            gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeD);
            gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeD);
            CreateGrid();
        }

        public void CreateGrid()
        {
            grid = new Node[gridSizeX, gridSizeY];
            Vector3 worldBottomLeft = transform.position -
                                      Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeD + nodeRadius) + Vector3.forward *
                                         (y * nodeD + nodeRadius);
                    bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                    grid[x, y] = new Node(walkable, worldPoint, x, y);
                }
            }
        }

        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbour = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }


                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;

                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbour.Add(grid[checkX, checkY]);
                    }
                }
            }

            return neighbour;
        }

        public Node NodeFromWorldPoint(Vector3 worldposition)
        {
            float percentX = (worldposition.x + gridWorldSize.x / 2) / gridWorldSize.x;
            float percentY = (worldposition.z + gridWorldSize.y / 2) / gridWorldSize.y;
            percentX = Mathf.Clamp01(percentX);
            percentY = Mathf.Clamp01(percentY);

            int x = (int) (Mathf.RoundToInt(gridSizeX - 1) * percentX);
            int y = (int) (Mathf.RoundToInt(gridSizeY - 1) * percentY);
            return grid[x, y];
        }

        public List<Node> path;

        public void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

            if (grid != null)
            {
                Node playerNode = NodeFromWorldPoint(player.position);
                foreach (Node n in grid)
                {
                    Gizmos.color = (n.walkable) ? Color.white : Color.black;
                    if (path != null)
                    {
                        if (path.Contains(n))
                        {
                            Gizmos.color = Color.red;
                        }
                    }

                    if (playerNode == n)
                    {
                        Gizmos.color = Color.green;
                    }

                    Gizmos.DrawCube(n.worldposition, Vector3.one); // * (nodeD - 0.1f)
                }
            }
        }
    }
}