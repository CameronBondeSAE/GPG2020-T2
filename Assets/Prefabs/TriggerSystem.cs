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
		public GameObject target;
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

		public ToggleState tState = ToggleState.Deactivated;

		public void Awake()
		{
			targetColour = target.GetComponent<ColourChanger>().currentColor;
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
						tState = ToggleState.Activated;
					}
				}
			}
			else
			{
				triggeredEvent.Invoke();
				tState = ToggleState.Activated;
			}
		}

		public void Deactivate()
		{
			releasedEvent.Invoke();
			tState = ToggleState.Deactivated;
		}

		private void OnTriggerEnter(Collider other)
		{
			isPlayerInside = true;
			_other = other;
			if (isUsingColourSystem)
			{
				_otherColourChanger = other.GetComponent<ColourChanger>();
				targetColour = target.GetComponent<ColourChanger>().currentColor;
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