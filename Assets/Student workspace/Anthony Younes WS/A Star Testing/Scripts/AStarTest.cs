using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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
    public int gridSizex;
    public int gridSizeY;
    
    //I'm not 100% sure of these lists but can be used to see what nodes have already been checked
    public List<Node> currentNode;
    public List<Node> neighbourNodes;
    public List<Node> openNodes;
    
   
   //TODO
   //A GIZMOS to see the line update ingame
   public void OnDrawGizmos(Node targetNode)
   {
       Gizmos.color = Color.yellow;
   }

   void Start()
    {
        
    }

    

    public void NodeGrid()
    {
        foreach (Node n in nodeArray)
        {
            
        }

        
    }
    
}
