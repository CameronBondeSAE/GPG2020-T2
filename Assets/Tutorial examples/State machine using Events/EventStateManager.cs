public class EventStateManager
{
	public EventState currentState;

	public void ChangeState(EventState newState)
	{
		if (currentState != null)
		{
			currentState.active = false;
			currentState.Exit?.Invoke();
		}
		
		if (newState != null)
		{
			newState.active = true;
			newState.Enter?.Invoke();
			currentState = newState;
		}
	}

	public void ExecuteCurrentState()
	{
		currentState?.Execute?.Invoke();
	}
}