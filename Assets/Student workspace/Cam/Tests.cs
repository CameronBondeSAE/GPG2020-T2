using System;
using Mirror;
using UnityEngine;

namespace Student_workspace.Cam
{
	public class Tests : MonoBehaviour
	{
		public float speedScale;

		[ShowInInspector]
		private float speed;

		public float Speed
		{
			get
			{
				
				return speed;
			}
		}


		private void Start()
		{
			GameObject go = new GameObject();

			go.AddComponent<Rigidbody>();
			go.AddComponent<Collider>();
		}
	}
}