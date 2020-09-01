using UnityEngine;
using UnityEngine.InputSystem;

public class EventDrivenState_Beginner : MonoBehaviour
{
	// You COULD make the statemanager a component, but I've just made it a pure c# class, so I have to 'new' it myself (unlike components/monobehaviours)
	public EventStateManager EventStateManager = new EventStateManager();

	public EventState idle = new EventState();
	public EventState run  = new EventState();

	void Start()
	{
		Debug.Log("Press space to change to run state. HACK: It's just to test");
		
		// I'm ASSIGNING the variables to specific functions. Remember, variable just POINT to things... ANY thing! ints, strings, gameobjects, components... and... FUNCTIONS!
		idle.Enter   = OnIdleEnter;
		idle.Execute = OnIdleExecute;
		idle.Exit    = OnIdleExit;

		run.Enter   = OnRunEnter;
		run.Execute = OnRunExecute;

		EventStateManager.ChangeState(idle);
	}

	void Update()
	{
		EventStateManager.ExecuteCurrentState();
	}

	private void OnRunEnter()
	{
		Debug.Log("OnRunEnter");
	}

	private void OnRunExecute()
	{
		Debug.Log("OnRunExecute");
		
		// Just me forcing the state to change for testing
		if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
		{
			EventStateManager.ChangeState(run);
		}
	}

	private void OnIdleEnter()
	{
		Debug.Log("OnIdleEnter");
	}

	private void OnIdleExecute()
	{
		Debug.Log("OnIdleExecute");
	}

	private void OnIdleExit()
	{
		Debug.Log("OnIdleExit");
	}
}