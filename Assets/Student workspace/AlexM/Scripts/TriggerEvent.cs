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
		
		[Tooltip("This option will only allow one mask to be chosen at a time. <DEFAULT TO PLAYER_BODY>")]
		public LayerMask mask;
		
		public Material usingColorChanger;

		private Collider _other;
		
		public void Activate()
		{
			if (usingColorChanger != null)
			{
				if (_other.gameObject.GetComponent<Renderer>().material.color == usingColorChanger.color)
				{
					//if ((mask.value & 1<<other.gameObject.layer) != 12)
					if(mask == LayerMask.NameToLayer("Player_Body"))
					{
						pressedEvent.Invoke();
					}
				}
			}
			else if (usingColorChanger == null)
			{
				if ((mask.value & 1 << _other.gameObject.layer) != 12)
				{
					pressedEvent.Invoke();
				}
			}
		}

		public void Deactivate()
		{
			if ((mask.value & 1 << _other.gameObject.layer) != 12)
			{
				releasedEvent.Invoke();
			}
		}
		
		void OnTriggerEnter(Collider other)
		{
			_other = other;
			Activate();
		}

		private void OnTriggerExit(Collider other)
		{
			_other = other;
			Deactivate();
		}
	}
}