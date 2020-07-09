using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelUsingInspectorEvent : MonoBehaviour
{


	public void ThingToDoWhenIDie()
	{
		Debug.Log("I'm a barrel using the inspector to hook up the Die event... and I'm dead now");
		Destroy(gameObject);
	}
}
