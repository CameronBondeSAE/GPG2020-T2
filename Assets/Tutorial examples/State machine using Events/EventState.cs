using System;


[Serializable]
public class EventState
{
	// Action just means 'any function'. So these variables can point to a function
	// Action is a shortcut for this    "public delegate void Enter();"
	
	public event Action DoThing;

	public delegate void CamsDelegate(int number);

	public CamsDelegate withInt;
	
	public Action Enter;
	public Action Execute;
	public Action Exit;
	public bool   active;

	public void Thing()
	{
		withInt += WithInt;
		
		withInt?.Invoke(4);
		
	}

	private void WithInt(int number)
	{
		throw new NotImplementedException();
	}
}