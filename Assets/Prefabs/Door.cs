using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

namespace alexM
{
	public class Door : NetworkBehaviour
	{
		public GameObject target;
		[HideInInspector] public GameObject originalTarget;
		public Vector3 startPos, targetPos, doorPos;
		public float speed;
		
		[SyncVar] 
		public bool isOpening, isClosing;

		public GameObject door;

		public enum State
		{
			Opened,
			Opening,
			Closed,
			Closing
		}

		public State state = State.Closed;

		public UnityEvent openedEvent, openingEvent;
		public UnityEvent closedEvent, closingEvent;


		// Start is called before the first frame update
		void Awake()
		{
			originalTarget = target;
			startPos = door.transform.position;
			doorPos = startPos;
		}

		// void SetTarget(GameObject tgt)
		// {
		// 	if (target != null)
		// 	{
		// 		target = tgt;
		// 		targetPos = target.transform.position;
		// 	}
		// }

		public void Open()
		{
			if (!(state == State.Opening) && !(state == State.Closing))
			{
				targetPos = target.transform.position;
				state = State.Opening;
				openingEvent?.Invoke();
			}
			
			// if (!isOpening && !isClosing)
			// {
			// 	targetPos = target.transform.position;
			// 	isOpening = true;
			// }
			// else
			// {
			// 	isOpening = false;
			// }
		}

		public void Close()
		{
			if (!(state == State.Closing) && !(state == State.Opening))
			{
				targetPos = target.transform.position;
				state = State.Closing;
				closingEvent?.Invoke();
			}
			
			// if (!isClosing && !isOpening)
			// {
			// 	targetPos = startPos;
			// 	isClosing = true;
			// }
			// else
			// {
			// 	isClosing = false;
			// }
		}

		public bool isReached(Vector3 tgt)
		{
			var position = door.transform.position;
			var dist = Vector3.Distance(position, tgt);
			doorPos = position;

			if (dist <= 0.01f)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void Update()
		{
			//Do move stuff here
			if (state == State.Opening)
			{
				//openingEvent?.Invoke();
				//lerp to targetPos
				door.transform.position = Vector3.MoveTowards(doorPos, targetPos, 1f * Time.deltaTime * speed);

				if (isReached(target.transform.position))
				{
					openedEvent?.Invoke();
					state = State.Opened;
				}
			}
			else if (state == State.Closing)
			{
				//closingEvent?.Invoke();
				door.transform.position =
					Vector3.MoveTowards(door.transform.position, startPos, 1f * Time.deltaTime * speed);

				if (isReached(startPos))
				{
					closedEvent?.Invoke();
					state = State.Closed;
				}
			}
		}
	}
}