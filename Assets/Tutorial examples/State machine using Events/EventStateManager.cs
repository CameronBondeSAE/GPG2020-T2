public class EventStateManager
{
	public EventState currentState;

	public void ChangeState(EventState newState)
	{
		if (currentState != null) currentState.active = false;
		currentState?.Exit();
		newState.active = true;
		newState?.Enter();
		currentState = newState;
	}

	public void ExecuteCurrentState()
	{
		currentState?.Execute();
	}
}