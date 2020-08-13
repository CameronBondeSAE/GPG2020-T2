using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class CamGOAPJump : ReGoapAction<string, object>
{
	protected override void Awake()
	{
		base.Awake();
		
		preconditions.Set("hasHighHealth", true);
		effects.Set("doJump", true);
	}
}
