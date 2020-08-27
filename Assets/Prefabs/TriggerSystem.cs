using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using UnityEngine;
using UnityEngine.Events;

namespace alexM
{
	/// <summary>
	/// What do i want it to do?
	/// - Activate its target when a player enters/leaves the trigger zone of the object its attached to.
	/// - Check the colour of the object that entered the zone using our COLOURCHANGER system.
	/// - Be re-usable!
	/// </summary>
	public class TriggerSystem : MonoBehaviour
	{
		public bool isUsingColourSystem;
		[Tooltip("the colour of the object assigned to this slot will be what determines the colour you need to be in order to have it activate")]
		public GameObject ColourChangerTarget;
		public UnityEvent triggeredEvent, releasedEvent;
		
		private Collider _other;
		private ColourChanger _otherColourChanger;
		private Color targetColour;

		[HideInInspector]
		public bool isPlayerInside; //I know this isn't a great way to do this for multiplayer; just wanted to try it out!
		public enum ToggleState
		{
			Activated,
			Deactivated
		}

		public ToggleState toggleState = ToggleState.Deactivated;

		public void Awake()
		{
			if (isUsingColourSystem)
			{
				targetColour = ColourChangerTarget.GetComponent<ColourChanger>().currentColor;	
			}
		}

		public void Activate()
		{
			if (isUsingColourSystem)
			{
				if (_otherColourChanger != null)
				{
					if (_otherColourChanger.currentColor == targetColour)
					{
						triggeredEvent.Invoke();
						toggleState = ToggleState.Activated;
					}
				}
			}
			else
			{
				triggeredEvent.Invoke();
				toggleState = ToggleState.Activated;
			}
		}

		public void Deactivate()
		{
			releasedEvent.Invoke();
			toggleState = ToggleState.Deactivated;
		}

		private void OnTriggerEnter(Collider other)
		{
			isPlayerInside = true;
			_other = other;
			if (isUsingColourSystem)
			{
				_otherColourChanger = other.GetComponent<ColourChanger>();
				targetColour = ColourChangerTarget.GetComponent<ColourChanger>().currentColor;
			}

			Activate();
		}

		private void OnTriggerExit(Collider other)
		{
			isPlayerInside = false;
			_other = other;
			Deactivate();
		}

		
	}
}