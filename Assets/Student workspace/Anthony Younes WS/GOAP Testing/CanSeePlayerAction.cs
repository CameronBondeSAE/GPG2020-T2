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
    public LineOfSight lineOfSight;
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("* " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " - " + MethodBase.GetCurrentMethod().Name);
        effects.Set("Bezerker",true);
        
        
    }
    
    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        //Action Code
        lineOfSight.Los();
        
        //its successful
        doneCallback(this);
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

}
