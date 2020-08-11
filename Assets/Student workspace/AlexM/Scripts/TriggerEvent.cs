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
		public Material doorColor;
		private void Awake()
		{
			
		}


		void OnTriggerEnter(Collider other)
		{
			
			// int layerMask = 1 << 10;
			// layerMask = ~layerMask;

			if (doorColor != null)
			{
				if (other.gameObject.GetComponent<Renderer>().material.color == doorColor.color)
				{
					if ((mask.value & 1<<other.gameObject.layer) != 12)
					{
						pressedEvent.Invoke();
					}
					//Debug.Log(other.gameObject.GetComponent<Renderer>().material.color.ToString());
				}
			}
			else if (doorColor == null)
			{
				if ((mask.value & 1<<other.gameObject.layer) != 12)
				{
					pressedEvent.Invoke();
				}
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