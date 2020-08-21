using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEngine;
using UnityEngine.Events;

public class ReScanPath : MonoBehaviour
{
    public float rescanTime = 3f;
    public AStarTest aStar;

    public event Action scanNodeEvent;
    
    void Awake()
    {
        scanNodeEvent += OnscanNodeEvent;
    }
    

    public void OnscanNodeEvent()
    {
        StartCoroutine(ScanForNodes());
    }
    
    IEnumerator ScanForNodes()
    {
        scanNodeEvent?.Invoke();
        yield return new WaitForSeconds(rescanTime);
        aStar.CreateNodes(0,aStar.gridSize.x,0,aStar.gridSize.y);
    }

    

}





