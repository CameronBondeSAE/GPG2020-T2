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

    public Transform head;
    
    
    // public enum SortBy
    // {
    //     Random,
    //     Ordered,
    //     Loop
    // }
    
    private void Awake()
    {
        head = transform.Find("Head");
        rB = this.gameObject.GetComponent<Rigidbody>();

        if (random)
        {
            target = points[Random.Range(0,points.Count)].transform;
        }else if (order)
        {
            target = points[currTarget].transform;
        }
        else
        {

            target = GameObject.FindObjectOfType<PatrolPoint>().transform;

        }
        
        _dir = (target.position - transform.position).normalized;
    }

    public void TargetCheck()
    {//check distance to target, change target

        if (target)
        {
            dist = Vector3.Distance(target.position, transform.position);
        }
        
        if (dist <= 1.0f && !reached)
        {
            if (random)
            {
                targetInt = Random.Range(0, points.Count); 
            }else if (order)
            {
                reached = true;
                if (currTarget > (points.Count - 1))//Kind of works, still gives the index out of range when resetting at the end. sleep first fix later!
                {
                    currTarget = 0;
                }
                currTarget += 1;
                targetInt = currTarget;

            }else if (loop)
            {
                
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
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            head.transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
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