using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class ShootAction : ReGoapAction<string,object>
{
    public bool isShooting = true;
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("canSeePlayer",true);
        
        effects.Set("killGuy",true);
        // effects.Set("canSeePlayer",false);
        
    }

    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        if (isShooting)
        {
            Debug.Log("I am shooting the enemy");
            doneCallback(this);
        }
        else if(!isShooting)
        {
            failCallback(this);
        }

      
    }

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
