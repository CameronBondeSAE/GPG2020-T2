using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cam
{
	public class Door : MonoBehaviour
	{
		// Update is called once per frame
		public void Open()
		{
			Debug.Log("Open");
			gameObject.SetActive(false); // A CRAP way to open a door, but it works
		}
	}

}