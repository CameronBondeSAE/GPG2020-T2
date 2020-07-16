using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace alexM
{
	public class Patrol : MonoBehaviour
	{
		public bool doLookAtTarget, doMove;
		public bool random,         order, loop;

		public Transform[] loopTargetA;

		//public Transform loopTargetB;
		public  List<PatrolPoint> points;
		public  Rigidbody         rB;
		public  Transform         target;
		public  int               currTarget = 0;
		public  float             speedMulti;
		private float             dist;
		private Vector3           _dir;
		private bool              reached = false;
		private int               targetInt;


		// public enum SortBy
		// {
		//     Random,
		//     Ordered,
		//     Loop
		// }

		private void Awake()
		{
			rB = this.gameObject.GetComponent<Rigidbody>();
			PatrolType();
			_dir = (target.position - transform.position).normalized;
		}

		private void PatrolType()
		{
			if (random)
			{
				target = points[Random.Range(0, points.Count)].transform;
			}
			else if (order)
			{
				if (currTarget == (points.Count))
				{
					currTarget = 0;
				}
				else
				{
					currTarget++;
				}

				targetInt = currTarget;
				target    = points[targetInt].transform;
			}
			else
			{
				target = FindObjectOfType<PatrolPoint>().transform;
			}
		}


		public void TargetCheck()
		{
			//check distance to target, change target
			if (target)
			{
				dist = Vector3.Distance(target.position, transform.position);
			}

			if (dist <= 1.0f && !reached)
			{
				if (random)
				{
					targetInt = Random.Range(0, points.Count);
					target    = points[targetInt].transform;
				}
				else if (order)
				{
					if (currTarget >= (points.Count)
					) //Kind of works, still gives the index out of range when resetting at the end. sleep first fix later!
					{
						currTarget = 0;
					}
					else
					{
						currTarget += 1;
					}

					targetInt = currTarget;
					target    = points[targetInt].transform;
				}
				else if (loop)
				{
				}

				//target = points[targetInt].transform;
				_dir    = (target.position - transform.position).normalized;
				reached = true;
			}

			reached = false;
		}

		private void DoPatrol()
		{
			//Movement for patrolling
			TargetCheck();

			if (!reached)
			{
				//Moving
				rB.velocity = _dir * (speedMulti * Time.deltaTime);

				if (doLookAtTarget)
				{
					transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
				}
			}
		}

		private void Update()
		{
			if (doMove)
			{
				DoPatrol();
			}
		}
	}
}