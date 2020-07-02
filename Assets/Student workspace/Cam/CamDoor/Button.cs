using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Cam
{
	
	/// <summary>
	/// 
	/// </summary>
	public class Button : MonoBehaviour
	{
		// Unity's own event system
		public UnityEvent turnOnEvent;
		
		// C# events
		public event Action turnOnEventCSHARP;

		private void Start()
		{
			TurnOn();
		}

		public void TurnOn()
		{
			Debug.Log("On");
			
			if (turnOnEvent != null)
			{
				turnOnEvent.Invoke();
			}

			if (turnOnEventCSHARP != null)
			{
				turnOnEventCSHARP.Invoke();
			}
		}

		public void TurnOff()
		{
			Debug.Log("Off");
		}
	}

}