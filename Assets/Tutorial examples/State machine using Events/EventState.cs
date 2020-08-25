using System;

[Serializable]
public class EventState
{
	// Variables can POINT TO FUNCTIONS! It's just another piece of information, like numbers, strings etc. A function name is just another type of info really.
	// Action just means 'any function'. So these variables can point to a function
	// Action is a shortcut for this    "public delegate void Enter();"
	public Action Enter;
	public Action Execute;
	public Action Exit;
	public bool   active;
}