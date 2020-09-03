using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using alexM;
using Niall;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class BezerkerAction :  ReGoapAction<string,object>
{
    public float attackPower;
    public Rigidbody rb;
    public LineOfSight _lineOfSight;
    public Nearby nearby;
  protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }
    
    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        //Action Code
        // transform.LookAt(_lineOfSight.targets[0]);
        _lineOfSight.singleTarget = nearby.GetClosest().transform;
        if (_lineOfSight.Los())
        {
            transform.LookAt(_lineOfSight.singleTarget);
        }
       
        
        rb.AddForce(transform.forward * attackPower,ForceMode.Impulse);
        Debug.Log("YEET!!");

        //its successful
        doneCallback(this);
    }

    public override ReGoapState<string, object> GetPreconditions(GoapActionStackData<string, object> stackData)
    {
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
        preconditions.Set("canSeePlayer",true);
        return base.GetPreconditions(stackData);
    }

    public override ReGoapState<string, object> GetEffects(GoapActionStackData<string, object> stackData)
    {
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
        effects.Set("killGuy", true);
        return base.GetEffects(stackData);
    }

    //Record the action into the memory
    public override void Exit(IReGoapAction<string, object> next)
    {
        base.Exit(next);
        var worldState = agent.GetMemory().GetWorldState();
    
        foreach (var pair in effects.GetValues())
        {
            worldState.Set(pair.Key,pair.Value);
        }
    }
}

