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


		[Header("Object Settings")]
		[Tooltip("This option will determine if the Rigidbody is allowed control if its own gravity or not. <LEAVE THIS FALSE AS LONG AS useYaxis IS FALSE.>")]
		public bool useGravity = false;
		[Tooltip("This option will determine whether or not the object will move directly AT the target, or only its X and Z positions (Staying on the Y pos it is currently at.)")]
		public bool useYaxis = false;
		public float speedMulti = 100;
		[Tooltip("This is the distance to the target left before this component switches to the next target based on Current Move Type below")]
		public float targetReachedThreshold = 0.5f;
		
		[Header("Targeting/MoveType")]
		[Tooltip("Add as many Waypoint prefabs to your scene as you need and drag them all into this list for this component to work!")]
		public List<Waypoint> wayPoints;
		[SerializeField] private MoveType _currMoveType = MoveType.Ordered;
		[SerializeField] private DistanceType _currDistanceType = DistanceType.Center;
		
		
		[Header("Optional/Debug")]
		public bool AttachRigidbody;
		public Transform target;
		
		
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

		private enum DistanceType
		{
			Center,
			ClosestPoint
		}

		
		private TargetStatus _targetStatus = TargetStatus.NoTarget;
		private int _targetId = 0;
		private int _listCount;
		private Vector3 _dir;
		private Rigidbody RB;
		private float dist;
		private bool targetReached;
		private Collider _collider;

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
				TargetSetup();
			}

			_collider = GetComponent<Collider>();

		}

		bool isReached()
		{
			if (_targetStatus == TargetStatus.TargetFound)
			{
				if (_currDistanceType == DistanceType.ClosestPoint)
				{
					var tPosition = target.position;
					dist = Vector3.Distance(_collider.ClosestPointOnBounds(tPosition), tPosition);
				}
				else if (_currDistanceType == DistanceType.Center)
				{
					dist = Vector3.Distance(gameObject.transform.position, target.position);	
				}
				
				
				if (dist <= targetReachedThreshold)
				{
					targetReached = true;
					return true;
					//target Reached
				}
				else if (dist >= targetReachedThreshold)
				{
					targetReached = false;
					return false;
					//Not Reached
				}
			}
			return false;
		}

		void TargetSetup()
		{
			target = wayPoints[_targetId].transform;
			_dir = (target.position - transform.position).normalized;
			_dir = new Vector3(_dir.x, 0, _dir.z);
			_targetStatus = TargetStatus.TargetFound;	
		}
		
		void SelectTarget()
		{
		#region CountAndReset

			_listCount = wayPoints.Count;
			
		#endregion

			switch (_currMoveType)
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

					TargetSetup();
					break;
				case MoveType.Random:
					//Debug.Log("Set to Random");
					_targetId = Random.Range(0, _listCount);

					TargetSetup();
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

					TargetSetup();
					break;
			}


			//target = points[_targetId].transform;


			// Debug.Log("i Still happen");
		}

		void MoveTo(Transform target)
		{
			
			if (!useGravity)
			{
				RB.useGravity = false;
			}
			else
			{
				RB.useGravity = true;
			}

			if (!useYaxis)
			{
				RB.velocity = new Vector3(_dir.x, 0, _dir.z) * (speedMulti * Time.deltaTime);
			}
			else
			{
				RB.velocity = _dir * (speedMulti * Time.deltaTime);
			}
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