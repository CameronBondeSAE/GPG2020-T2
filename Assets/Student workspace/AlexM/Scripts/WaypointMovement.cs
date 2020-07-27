using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace alexM
{
	public class WaypointMovement : MonoBehaviour
	{
	#region Variables

		public List<Waypoint> wayPoints;
		public float speedMulti = 100, targetReachedThreshold = 0.5f;
		public Transform target;
		public bool AttachRigidbody;

		private enum MoveType
		{
			Ordered,
			Random,
			LoopBetween
		}

		private enum TargetStatus
		{
			NoTarget,
			TargetFound
		}

		[SerializeField] private MoveType _currentType = MoveType.Ordered;
		private TargetStatus _targetStatus = TargetStatus.NoTarget;
		private int _targetId = 0;
		private int _listCount;
		private Vector3 _dir;
		private Rigidbody RB;
		private float dist;
		private bool targetReached;

	#endregion

		private void Awake()
		{
			if (!RB)
			{
				if (AttachRigidbody)
				{
					if (!gameObject.GetComponent<Rigidbody>())
					{
						gameObject.AddComponent<Rigidbody>();
						RB = gameObject.GetComponent<Rigidbody>();
						RB.constraints = RigidbodyConstraints.FreezeRotation;
					}
				}
				else
				{
					if (gameObject.GetComponent<Rigidbody>())
					{
						RB = gameObject.GetComponent<Rigidbody>();
					}
					else
					{
						Debug.Log(("(" + transform.name.ToString() +
						           "): Unable to get a rigidbody on this object..is one attached?"));
						Debug.Log(
							"If you'd like this script to handle any requirements, get out of PlayMode, and tick the AttachRigidbody bool");
					}
				}
			}


			if (_targetStatus == TargetStatus.NoTarget)
			{
				_targetId = 0;
				target = wayPoints[_targetId].transform;
				_targetStatus = TargetStatus.TargetFound;
				_dir = (target.position - transform.position).normalized;
			}
		}

		bool isReached()
		{
			if (_targetStatus == TargetStatus.TargetFound)
			{
				dist = Vector3.Distance(gameObject.transform.position, target.position);
				if (dist < targetReachedThreshold)
				{
					targetReached = true;
					return true;
					//target Reached
				}
				else if (dist > targetReachedThreshold)
				{
					targetReached = false;
					return false;
					//Not Reached
				}
			}
			// else
			// {
			// 	return true;
			// }

			return false;
		}

		void SelectTarget()
		{
		#region CountAndReset

			_listCount = wayPoints.Count;
			// if (_targetId == _maxCount)
			// {
			// 	_targetId = 0;
			// }

		#endregion

			switch (_currentType)
			{
				case MoveType.Ordered:
					//Debug.Log("Set to Ordered");

					if (_targetId < (_listCount - 1))
					{
						_targetId++;
					}
					else
					{
						_targetId = 0;
					}

					target = wayPoints[_targetId].transform;
					_dir = (target.position - transform.position).normalized;
					_targetStatus = TargetStatus.TargetFound;
					break;
				case MoveType.Random:
					//Debug.Log("Set to Random");
					_targetId = Random.Range(0, _listCount);

					target = wayPoints[_targetId].transform;
					_dir = (target.position - transform.position).normalized;
					_targetStatus = TargetStatus.TargetFound;
					break;
				case MoveType.LoopBetween:
					//Debug.Log("Set to LoopBetween");
					//Just for now making this only loop between the first two slots of the list for convenience
					if (_targetId == 1)
					{
						_targetId = 0;
					}
					else
					{
						_targetId++;
					}

					target = wayPoints[_targetId].transform;
					_dir = (target.position - transform.position).normalized;
					_targetStatus = TargetStatus.TargetFound;
					break;
			}


			//target = points[_targetId].transform;


			// Debug.Log("i Still happen");
		}

		void MoveTo(Transform target)
		{
			RB.velocity = _dir * (speedMulti * Time.deltaTime);
		}

		private void FixedUpdate()
		{
			if (_targetStatus == TargetStatus.NoTarget || isReached())
			{
				SelectTarget();
			}
			else if (_targetStatus == TargetStatus.TargetFound && !isReached())
			{
				MoveTo(target);
			}
		}
	}
}