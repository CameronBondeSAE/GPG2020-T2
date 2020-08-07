using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineofSight : MonoBehaviour
{
    public Transform sight;
    public float range;


    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay (transform.position,sight.forward*range,Color.red,2f,false);
        if(Physics.Raycast(transform.position,sight.forward,out hit,range))
        {
            // Debug.Log("" + gameObject.name);
            Debug.Log("We found Target! = " + hit.collider.name);
        }
        else {
            Debug.Log("I found nothing " );
        }
    }
}
