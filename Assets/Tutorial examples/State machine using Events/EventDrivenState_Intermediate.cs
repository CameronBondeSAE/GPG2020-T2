using UnityEngine;
using UnityEngine.InputSystem;

public class EventDrivenState_Intermediate : MonoBehaviour
{
	public EventState idle = new EventState();
	public EventState run  = new EventState();

	public EventStateManager EventStateManager = new EventStateManager();

	// Start is called before the first frame update
	void Start()
	{
		// Here I'm using "Lambdas" so I don't have to define whole functions for everything. You can mix and match.
		idle.Enter   = () => Debug.Log("IDLE BEGIN");
		idle.Execute = () => Debug.Log("IDLE GO!");
		idle.Exit    = () => Debug.Log("IDLE END");

		run.Enter   = () => Debug.Log("run begin");
		run.Execute = () => Debug.Log("run execute");

		EventStateManager.ChangeState(idle);
	}

	// Update is called once per frame
	void Update()
	{
		EventStateManager.ExecuteCurrentState();

		// Just me forcing the state to change for testing
		if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
		{
			EventStateManager.ChangeState(run);
		}
	}
}
