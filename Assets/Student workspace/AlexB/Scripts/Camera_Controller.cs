using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace alexM
{
	public class Camera_Controller : MonoBehaviour
	{
		public                   GameObject cameraLocation;
		[HideInInspector] public Camera     cam;
		private                  Vector3    camPos;

		void Setup()
		{
			GameObject o;
			o = this.gameObject;
			cameraLocation.AddComponent<Camera>();
			cam    = cameraLocation.GetComponent<Camera>();
			camPos = cam.transform.position;
			camPos = cameraLocation.transform.position;
		}

		// Vector3 Offset(Vector3 plrPos)
		// {
		//     camPos = new Vector3(playerPos.x, playerPos.y + 2, playerPos.z - 4);
		//     return camPos;
		// }

		private void Awake()
		{
			Setup();
		}
	}
}