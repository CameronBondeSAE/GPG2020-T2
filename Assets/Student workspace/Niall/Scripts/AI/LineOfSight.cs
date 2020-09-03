using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Niall
{
	public class LineOfSight : MonoBehaviour
	{
		public  Transform        eyes;
		public  Transform        singleTarget;
		public  List<Transform>  targets = new List<Transform>();
		private Transform        _target;
		public  float            range;
		
		[SerializeField]
		private bool             haveLOS;

		public  UnityEvent<bool> changedLOS;
		public  float            Degrees = 25.0f;
		public  Nearby           nearby;


		void Update()
		{
			if (targets.Count>0 || singleTarget)
			{
				CheckLOS();
			}
		}

		public bool CheckLOS()
		{
			haveLOS = false;

			// Wipe out multiple target if we've manually set a single one. Just for ease of use
			if (singleTarget)
			{
				targets.Clear();
				targets.Add(singleTarget);
			}

			foreach (Transform target in targets)
			{
				_target = target.transform;

				RaycastHit hitt;

				Vector3 targetDir = _target.position - transform.position;
				float   angle     = Vector3.Angle(targetDir, transform.forward);

				if (Physics.Linecast(eyes.position, target.position, out hitt))
				{
					if (angle < Degrees)
					{
						haveLOS = true;

						Debug.DrawLine(eyes.position, hitt.point, Color.red);
					}
				}
			}

			return haveLOS;
		}
	}
}