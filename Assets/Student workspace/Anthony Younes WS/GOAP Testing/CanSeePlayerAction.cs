using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Niall;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace AnthonyY
{
    public class CanSeePlayerAction : ReGoapAction<string,object>
{
    public bool canSeePlayer = true;
    private LineOfSight _lineOfSight;
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);

        // effects.Set("canSeePlayer",false);
    }
    
    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        if (canSeePlayer)
        {
            _lineOfSight.Los();
        }
        doneCallback(this);
    }

    public override ReGoapState<string, object> GetPreconditions(GoapActionStackData<string, object> stackData)
    {
        return base.GetPreconditions(stackData);
    }

    public override ReGoapState<string, object> GetEffects(GoapActionStackData<string, object> stackData)
    {
        effects.Set("canMoveTowardsPlayer",true);
        effects.Set("canPatrol",false);
        // Debug.Log("I can see the enemy");
        
        return base.GetEffects(stackData);
    }
    public override void PlanEnter(IReGoapAction<string, object> previousAction, IReGoapAction<string, object> nextAction, ReGoapState<string, object> settings, ReGoapState<string, object> goalState)
    {
        base.PlanEnter(previousAction, nextAction, settings, goalState);
    }

    public override void PlanExit(IReGoapAction<string, object> previousAction, IReGoapAction<string, object> nextAction, ReGoapState<string, object> settings, ReGoapState<string, object> goalState)
    {
        base.PlanExit(previousAction, nextAction, settings, goalState);
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

}
