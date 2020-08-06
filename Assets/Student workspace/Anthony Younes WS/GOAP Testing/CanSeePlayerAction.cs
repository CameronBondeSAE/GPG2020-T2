using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class CanSeePlayerAction : ReGoapAction<string,object>
{
    public bool canSeePlayer = true;
    protected override void Awake()
    {
        base.Awake();
        // effects.Set("canSeePlayer",false);
    }
    
    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        
    
        doneCallback(this);
    }

    public override ReGoapState<string, object> GetEffects(GoapActionStackData<string, object> stackData)
    {
        if (canSeePlayer)
        {
            effects.Set("canSeePlayer",true);
            Debug.Log("I can see the enemy");
        }
        return base.GetEffects(stackData);
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
