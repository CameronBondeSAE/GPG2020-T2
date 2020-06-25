using System;
using UnityEngine;

namespace Student_workspace.Cam
{
	public class Tests : MonoBehaviour
	{

		private void Start()
		{
			GameObject go = new GameObject();

			go.AddComponent<Rigidbody>();
			go.AddComponent<Collider>();
		}
	}
}