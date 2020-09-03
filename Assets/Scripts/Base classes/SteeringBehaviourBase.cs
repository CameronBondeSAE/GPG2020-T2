using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviourBase : MonoBehaviour
{
	public  Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
		if (rb==null)
		{
			rb = GetComponent<Rigidbody>();

			if (rb==null)
			{
				Debug.LogError("This needs a rigidbody set (or one this GO)", this);
			}
		}
    }
}
