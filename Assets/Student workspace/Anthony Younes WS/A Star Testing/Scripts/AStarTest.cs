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
        public Node nodeStart;
        public Node nodeGoal;
        public Node currentNode;
        
        //maybe put all cost variables 
        public float h_cost;
        private float f_cost;
        private float g_cost;


        //TODO
        //A GIZMOS to see the line update ingame
        public void OnDrawGizmos()
        {
            //Gizmos.color = Color.yellow;
        }

        void Start()
        {
            openNodes.Add(nodeStart);
            openNodes.Add(nodeGoal);

        }

        //create f,g,h values
        public void calculateHeuristics(Node node)
        {
            //g_cost = (node.parent - nodeGoal.x);
           // g_cost = Math.Abs(node.y - nodeGoal.y);

            
        }
        

        public void nodeSearch()
        {
            while (openNodes.Count > 0)
            {
                //currentNode equals lowest f cost
                //remove currentNode from open List
                //add it to closed List
                
                
                
                foreach (Node n in nodeArray)
                {
                    if (n.Equals(currentNode))
                    {
                        continue;
                    }
                   
                    
                  
                    
                }
                
                
                if (currentNode.Equals(nodeGoal))
                {
                    Debug.Log("We have reached the goal");
                    //yay we made it
                
                }
                /*else(!currentNode.Equals(nodeGoal))
                {
                    Debug.Log("Cannot find path");
                }*/
            }
        }

        public void neighbourSearch()
        {
            
        }

    }

}
