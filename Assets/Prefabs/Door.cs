﻿using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

namespace alexM
{
	public class Door : NetworkBehaviour
	{
	#region Variables

		[Header("Settings")]
		public float speed;

		public bool autoClose;
		public float timeToClose;
		
		[HideInInspector, SyncVar] public bool isOpening, isClosing;

		[Header("Door Parts")]
		public GameObject hinge;
		public GameObject door;
		public GameObject target;
		private ColourChanger _colourChanger;
		private GameObject originalTarget;
		private Vector3 startPos, doorPos;
		[SyncVar] private Vector3 targetPos;


		public enum State
		{
			Opened,
			Opening,
			Closed,
			Closing
		}

		
		[Header("States and Events")]
		public UnityEvent openedEvent, openingEvent;
		public UnityEvent closedEvent, closingEvent;
		
		[SyncVar]
		public State state = State.Closed;
	#endregion
		
		void Awake()
		{
			if (GetComponent<ColourChanger>() != null)
			{
				_colourChanger = GetComponent<ColourChanger>();
				_colourChanger.currentColor = door.GetComponent<Renderer>().material.color;
			}
			
			originalTarget = target;
			startPos = hinge.transform.position;
			doorPos = startPos;
		}

		public void Open()
		{
			if (isServer)
			{
				if (!(state == State.Opening) && !(state == State.Closing))
				{
					targetPos = target.transform.position;
					state     = State.Opening;
					openingEvent?.Invoke();
				}
			}
		}

		public void Close()
		{
			if (isServer)
			{
				if (!(state == State.Closing) && !(state == State.Opening))
				{
					targetPos = target.transform.position;
					state     = State.Closing;
					closingEvent?.Invoke();
				}
			}
		}

		public bool isReached(Vector3 tgt)
		{
			var position = hinge.transform.position;
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

		IEnumerator doWait(float cd)
		{
			yield return new WaitForSeconds(cd);
			if (state == State.Opened)//Incase its in some other state by the time we get here- stop this from activating and disturbing the other code.
			{
				Close();	
			}
		}

		private void Update()
		{
			switch (state)
			{
				case State.Opening:
					openingEvent?.Invoke();
					hinge.transform.position = Vector3.MoveTowards(doorPos, targetPos, 1f * Time.deltaTime * speed);

					if (isReached(target.transform.position))
					{
						state = State.Opened;
					}
					break;
				case State.Opened:
					//I would like to check if the player is still inside the triggerzone but havent throught of a great way to do this yet.
					openedEvent?.Invoke();
					
					if (autoClose)
					{
						StartCoroutine(doWait(timeToClose));	
					}
					break;
				case State.Closing:
					closingEvent?.Invoke();
					hinge.transform.position = Vector3.MoveTowards(hinge.transform.position, startPos, 1f * Time.deltaTime * speed);

					if (isReached(startPos))
					{
						state = State.Closed;
					}
					break;
				case State.Closed:
					closedEvent?.Invoke();
					break;
			}
		}
	}
}