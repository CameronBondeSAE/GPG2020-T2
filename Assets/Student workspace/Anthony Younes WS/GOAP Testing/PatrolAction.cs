using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using alexM;
using AnthonyY;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace AnthonyY
{ 
    public class PatrolAction : ReGoapAction<string,object>
{
    private bool canPatrol = true;
    private Patrol _patrol;
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
    }

    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
    }
    
    public override ReGoapState<string, object> GetPreconditions(GoapActionStackData<string, object> stackData)
    {
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
        preconditions.Set("canSeePlayer",false);
        return base.GetPreconditions(stackData);
    }
    
    public override ReGoapState<string, object> GetEffects(GoapActionStackData<string, object> stackData)
    {
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
        if (canPatrol)
        {
            effects.Set("canPatrol",true);
            Debug.Log("I am strolling around the map");

        }
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
