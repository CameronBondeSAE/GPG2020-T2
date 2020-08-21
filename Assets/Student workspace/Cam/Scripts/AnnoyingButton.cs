using System;
using System.Collections;
using System.Collections.Generic;
using alexM;
using Niall;
using UnityEngine;

public class AnnoyingButton : MonoBehaviour
{
	public  WaypointMovement WaypointMovement;
	public  LineOfSight      LineOfSight;
	private Vector3          target;

	// Start is called before the first frame update
    void Awake()
    {
		// WaypointMovement.activate = false;
        // LineOfSight.changedLOS.AddListener(SawPlayerStartMoving);
		WaypointMovement.TargetChanged += WaypointMovementOnTargetChanged;
	}

	private void WaypointMovementOnTargetChanged(Transform obj)
	{
		target = obj.position;
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 4f);
	}

	private void SawPlayerStartMoving(bool arg0)
	{
		// If it saw ANY player
		if (arg0 == true)
		{
			// WaypointMovement.activate = true;
		}
	}
}
