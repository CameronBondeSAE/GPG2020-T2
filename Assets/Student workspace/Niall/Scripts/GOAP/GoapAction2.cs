using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;


public class GoapAction2 : ReGoapAction<string, object>
{
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("doAction",true);
        effects.Set("doneAction", true);
    }
}
