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
		public LayerMask mask;
		private void Awake()
		{
			
		}


		void OnTriggerEnter(Collider other)
		{
			
			// int layerMask = 1 << 10;
			// layerMask = ~layerMask;
			
			if ((mask.value & 1<<other.gameObject.layer) != 12)
			{
				pressedEvent.Invoke();
			}
			
			//Debug.Log("Zone was entered");
		}

		private void OnTriggerExit(Collider other)
		{
			if ((mask.value & 1<<other.gameObject.layer) != 12)
			{
				releasedEvent.Invoke();
			}
			//Debug.Log("Zone was left");
		}
	}
}