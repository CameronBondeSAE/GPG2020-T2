using System.Collections;
using System.Collections.Generic;
using alexM;
using Niall;
using UnityEngine;

public class AnnoyingButton : MonoBehaviour
{
	public WaypointMovement WaypointMovement;
	public LineOfSight      LineOfSight;
	
    // Start is called before the first frame update
    void Start()
    {
        LineOfSight.changedLOS.AddListener(SawPlayerStartMoving);
    }

	private void SawPlayerStartMoving(bool arg0)
	{
		if (arg0 == true)
		{
			WaypointMovement.Start();
		}
	}
}
