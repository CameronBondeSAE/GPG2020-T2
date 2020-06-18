using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AstarGrid : MonoBehaviour
{
  private Array[] OpenNodes;

  private Array[] ClosedNodes;




  void Start()
  {
    GetComponent<AStarShiz>().Open = false;
  }

  void Update()
  {
    
  }
}