using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class Patrol : MonoBehaviour
{
    public bool random, order, loop;
    public List<PatrolPoint> points;
    public Rigidbody rB;
    public Transform target;
    public int currTarget;
    public float speedMulti;
    [HideInInspector]
    public float dist;
    private Vector3 _dir;
    [HideInInspector]
    public bool reached = false;

    private int targetInt;
    // public enum SortBy
    // {
    //     Random,
    //     Ordered,
    //     Loop
    // }
    
    private void Awake()
    {
        rB = this.gameObject.GetComponent<Rigidbody>();

        if (random)
        {
            //target = points[Random.Range(0,points.Count)].transform;
        }else if (order)
        {
            target = points[currTarget].transform;
        }
        
        _dir = (target.position - transform.position).normalized;
    }

    public void TargetCheck()
    {//check distance to target, change target
        
        dist = Vector3.Distance(target.position, transform.position);
        
        if (dist <= 1.0f && !reached)
        {
            if (random)
            {
                targetInt = Random.Range(0, points.Count); 
            }else if (order)
            {
                // for (int i = 0; i < points.Count; i++)
                // {
                //     targetInt = i;
                //     reached = true;
                //     Debug.Log("Target: " + i.ToString());
                // } 

                reached = true;
                if (currTarget > (points.Count - 1))//Kind of works, still gives the index out of range when resetting at the end. sleep first fix later!
                {
                    currTarget = 0;
                }
                currTarget += 1;
                targetInt = currTarget;

            }
            
            target = points[targetInt].transform;
            _dir = (target.position - transform.position).normalized;
            reached = true;
        }
        reached = false;
    }
    
    private void DoPatrol()
    {//Movement for patrolling
        TargetCheck();
        //speed = rB.velocity.magnitude;
        if (!reached)
        {
            rB.velocity = _dir * (speedMulti * Time.deltaTime);
        }
    }

    private void Update()
    {
        DoPatrol();
    }
}


//Tasks to do:
/*
    Make options for the patrols, like patrol in list order(done), or loop patrol between A and B
    Destroy objects on contact (only certain objects)
*/