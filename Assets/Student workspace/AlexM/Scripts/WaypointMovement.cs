using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace alexM
{
	public class WaypointMovement : MonoBehaviour
	{
	#region Variables


		[Header("Object Settings")]
		
		[HideInInspector]public bool activate = true;
		[Tooltip("You can disable movement if you want to do your own or if you want to toggle it on via event/trigger later")]
		public bool movement;
		[Tooltip("If this is set to TRUE it will end the movement loop after reaching the limit set here.")]
		public bool limitLoops = false;
		[SerializeField, Tooltip("This is only needed if isLooping is TRUE")] 
		private int maxLoops;
		public bool goBackToStart = true;
		[Tooltip("The delay before the object starts its movement cycle")]
		public float startDelay = 0;
		[Tooltip("This option will determine if the Rigidbody is allowed control if its own gravity or not. <LEAVE THIS FALSE AS LONG AS useYaxis IS FALSE.>"), HideInInspector]
		public bool useGravity = false;
		[Tooltip("This option will determine whether or not the object will move directly AT the target, or only its X and Z positions (Staying on the Y pos it is currently at.)")]
		public bool useYaxis = false;
		public float speedMulti = 2;
		[Tooltip("This is the distance to the target left before this component switches to the next target based on Current Move Type below")]
		public float targetReachedThreshold = 0.01f;
		
		[Header("Targeting/MoveType")]
		[Tooltip("Add as many Waypoint prefabs to your scene as you need and drag them all into this list for this component to work!")]
		public List<Waypoint> wayPoints;
		[SerializeField] private MoveType _currMoveType = MoveType.Ordered;
		[SerializeField] private DistanceType _currDistanceType = DistanceType.Center;
		
		
		[Header("Optional/Debug")]
		public bool attachRigidbody;
		public Transform target;

		public event Action<Transform> TargetChanged;
		
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
		[SerializeField]private int loopCount;

		
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
				if (attachRigidbody)
				{
					if (!gameObject.GetComponent<Rigidbody>())
					{
						gameObject.AddComponent<Rigidbody>();
						RB             = gameObject.GetComponent<Rigidbody>();
						RB.isKinematic = true;
					}
				}
				else
				{
					if (gameObject.GetComponent<Rigidbody>())
					{
						RB = gameObject.GetComponent<Rigidbody>();
						
						if (!RB.isKinematic)
							RB.isKinematic = true;
						
						
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

			_collider = GetComponent<Collider>();

			
			if (!useGravity)
			{
				RB.useGravity = false;
			}
			else
			{
				RB.useGravity = true;
			}
		}

		private void Start()
		{
			if (_targetStatus == TargetStatus.NoTarget)
			{
				_targetId = 0;
				TargetSetup();
			}
		}

		bool isReached()
		{
			if (_targetStatus == TargetStatus.TargetFound)
			{
				if (_currDistanceType == DistanceType.ClosestPoint)
				{
					var tPosition                  = target.position;
					if (!(_collider is null)) dist = Vector3.Distance(_collider.ClosestPointOnBounds(tPosition), tPosition);
				}
				else if (_currDistanceType == DistanceType.Center)
				{
					if (useYaxis)
					{
						dist = Vector3.Distance(gameObject.transform.position, target.position);
					}
					else
					{
						var targetPosition = target.position;
						Vector3 targetPosOffset = new Vector3(targetPosition.x,transform.position.y, targetPosition.z);
						dist = Vector3.Distance(gameObject.transform.position, targetPosOffset);
					}
				}
				
				
				if (dist <= targetReachedThreshold)
				{
					targetReached = true;
					if (limitLoops)
					{
						if (loopCount >= maxLoops)
						{
							movement = false;
						}
					}
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

		public void ToggleMovement()
		{
			if (startDelay > 0)
			{
				StartCoroutine(startCD(startDelay));
			}
			else
			{
				if (!movement)
				{
					movement = true;
					loopCount = 0;
				}
			}
		}

		IEnumerator startCD(float cd)
		{ 
			yield return new WaitForSeconds(cd);
			if (!movement)
			{
				movement = true;
				loopCount = 0;
			}
		}

		void TargetSetup()
		{
			if (wayPoints != null && wayPoints[_targetId])
			{
				target = wayPoints[_targetId].transform;
				_dir = (target.position - transform.position).normalized;
				if (!useYaxis)
				{
					_dir = new Vector3(_dir.x, 0, _dir.z);
				}
				else
				{
					_dir = new Vector3(_dir.x, _dir.y, _dir.z);
				}
				_targetStatus = TargetStatus.TargetFound;

				TargetChanged?.Invoke(target);
			}
		}

		
		
		void SelectTarget()
		{
			_listCount = wayPoints.Count;

	//TODO:This will run endlessly and needs to be improved on later!
	#region LoopStuff

		if (limitLoops)
		{
			if (loopCount >= maxLoops)
			{
				if (goBackToStart)
				{
					_targetId = 0;
					TargetSetup();
				}
				return;
			}
		}

			if (_targetId == (_listCount - 1))
			{
				loopCount++;
			}

		#endregion
			switch (_currMoveType)
			{
				case MoveType.Ordered:
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
					_targetId = Random.Range(0, _listCount);

					TargetSetup();
					break;
				case MoveType.LoopBetween:
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
				
				RB.MovePosition(transform.position + _dir * (Time.fixedDeltaTime * speedMulti));
			}
			else
			{
				
				RB.MovePosition(transform.position + _dir * (Time.fixedDeltaTime * speedMulti));
			}
		}

		private void FixedUpdate()
		{
			if (activate)
			{
				if (_targetStatus == TargetStatus.NoTarget || isReached())
				{
					SelectTarget();
				}
				else if (movement && _targetStatus == TargetStatus.TargetFound && !isReached())
				{
					MoveTo(target);
				}
			}
		}
	}
}