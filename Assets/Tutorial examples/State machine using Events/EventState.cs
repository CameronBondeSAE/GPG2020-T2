using System;

[Serializable]
public class EventState
{
	// Action just means 'any function'. So these variables can point to a function
	// Action is a shortcut for this    "public delegate void Enter();"
	public Action Enter;
	public Action Execute;
	public Action Exit;
	public bool   active;
}