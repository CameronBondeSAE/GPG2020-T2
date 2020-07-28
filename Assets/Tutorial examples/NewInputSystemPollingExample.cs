using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystemPollingExample : MonoBehaviour
{
	// This is how you 'poll' the inputsystem, similar to the old system
	// NOTE: It's much better to use the event driven Actionmap setup. This is ok for debugging and quick tests though
	
    // Update is called once per frame
    void Update()
    {
		// Polling example (use Events though)
        // if (InputSystem.GetDevice<Keyboard>().spaceKey.isPressed)
        // {
            // Debug.Log("Test polling input system");
        // }
    }
}
