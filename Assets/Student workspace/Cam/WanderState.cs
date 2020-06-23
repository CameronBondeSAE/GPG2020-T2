using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : StateMachineBehaviour
{
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		
		Debug.Log("Wander state enter");
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate(animator, stateInfo, layerIndex);
		
		Debug.Log("Wander state update");
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateExit(animator, stateInfo, layerIndex);
		
		Debug.Log("Wander state exit");
	}
}
