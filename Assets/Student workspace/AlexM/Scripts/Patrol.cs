using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class Patrol : MonoBehaviour
{
    public List<PatrolPoint> points;
    public Rigidbody rB;
    public Transform target;
    public float speedMulti;
    [HideInInspector]
    public float dist;
    private Vector3 _dir;
    [HideInInspector]
    public bool reached = false;
    //public float speed;
    private void Awake()
    {
        rB = this.gameObject.GetComponent<Rigidbody>();
        target = points[Random.Range(0,points.Count)].transform;
        _dir = (target.position - transform.position).normalized;
    }

    public void TargetCheck()
    {//check distance to target, change target
        
        dist = Vector3.Distance(target.position, transform.position);
        
        if (dist <= 1.0f)
        {
            int targetInt = Random.Range(0, points.Count);
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
