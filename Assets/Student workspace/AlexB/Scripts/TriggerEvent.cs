using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;

namespace alexM
{
	public class TriggerEvent : MonoBehaviour
	{
		public UnityEvent pressedEvent, releasedEvent;

		// Start is called before the first frame update

		void OnTriggerEnter(Collider other)
		{
			pressedEvent.Invoke();
			//Debug.Log("Zone was entered");
		}

		private void OnTriggerExit(Collider other)
		{
			releasedEvent.Invoke();
			//Debug.Log("Zone was left");
		}
	}
}