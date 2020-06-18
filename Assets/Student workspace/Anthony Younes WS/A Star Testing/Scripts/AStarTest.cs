using System;
using System.Collections;
using System.Linq;
using Boo.Lang;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AnthonyY
{
    public class AStarTest : MonoBehaviour
    {
        public LayerMask unTouchableSurface; //mask for obstacles
    
        //lists of nodes to follow to get to the objective
        public Node[] nodeArray; 
        public float nodeDiameter;
        public float nodeRadius;
    
        //the grid itself
        //things that it may we need to take into the account
        public Vector2 gridSize;
        public Vector2 gridSizex;
        public Vector2 gridSizeY;
    
        //I'm not 100% sure of these lists but can be used to see what nodes have already been checked
        public List<Node> closedNodes;
        public List<Node> openNodes; //nodes that have been visited but not been expanded
        public List<Edge> neighbourNodes; //adjacency 
    
        //need a goal variable
        //start position
        public Node currentNode;
        
        //maybe put all cost variables 
        public float h;
        public float f;
        public float g = 0;

        public float normalCost = 10;
        public double diagonalCost = 1.414;


        //TODO
        //A GIZMOS to see the line update ingame
        public void OnDrawGizmos()
        {
            //Gizmos.color = Color.yellow;
        }

        void Start()
        {
           
           

        }

        //create f,g,h values
        public void calculateHeuristics(Node nodeStart,Node nodeGoal)
        {
            //g_cost = (node.parent - nodeGoal.x);
           // g_cost = Math.Abs(node.y - nodeGoal.y);

            
        }
        

        public void nodeSearch(Node nodeStart, Node nodeGoal)
        {
            openNodes.Add(nodeStart);
            openNodes.Add(nodeGoal);
           
            
            while (openNodes.Count > 0)
            {
                //currentNode equals lowest f cost
                //remove currentNode from open List
                //add it to closed List
                
                //f_cost = nodeStart.g_cost + calculateHeuristics(nodeStart, nodeGoal);
           
                
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
                
                //goal is found
                if (currentNode.Equals(nodeGoal))
                {
                    Debug.Log("We have reached the goal");
                    
                
                }
                /*else(!currentNode.Equals(nodeGoal))
                {
                    Debug.Log("Cannot find path");
                }*/
            }
        }

        public void neighbourSearch(Node node)
        {
            foreach ( Edge edge in neighbourNodes)
            {
                // g cost + normal cost
                //g cost + diagonal cost
                
            }
        }

        public void constructPath()
        {
            
        }

    }

}
