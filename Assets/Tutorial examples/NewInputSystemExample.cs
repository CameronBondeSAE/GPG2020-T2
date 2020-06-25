using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystemExample : MonoBehaviour
{
	public GameControls gameControls;
	
    // Start is called before the first frame update
    void Start()
	{
		gameControls = new GameControls();
		gameControls.InGame.Enable();
		gameControls.InGame.Fire.performed += FireOnperformed;
	}


	// Events should unsubscribe when they're done listening to it.
	private void OnDestroy()
	{
		gameControls.InGame.Fire.performed -= FireOnperformed;
	}

	// This is the function that runs when the input action event triggers
	private void FireOnperformed(InputAction.CallbackContext obj)
	{
		Debug.Log("Fire");
	}
}
