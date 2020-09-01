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
	public  Nearby           Nearby;

	private Vector3          target;
	private float            speed  =1f;
	public  bool             moving = true;

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
		if (moving)
		{
			transform.position = Vector3.MoveTowards(transform.position, target, Mathf.PerlinNoise(Time.deltaTime * 4f, 0 ) * speed);
		}
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
