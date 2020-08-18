using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEngine;

public class ReScanPath : MonoBehaviour
{
    public int rescanTime = 5;
    private void Update()
    {
        StartCoroutine(ScanForNodes());
    }

    IEnumerator ScanForNodes()
    {
        // gameObject.GetComponent<AStarTest>().CreateNodes();
        
        yield return new WaitForSeconds(rescanTime);
    }

    

}





