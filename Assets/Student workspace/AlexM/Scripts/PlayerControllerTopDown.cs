using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace alexM
{
	public class PlayerControllerTopDown : MonoBehaviour
	{
		public  float        speed;
		public  Vector3      direction;
		private GameControls GC;
		private Rigidbody    RB;
		private Camera       camera;
		private float        camOffset;

		private void Awake()
		{
			GC = new GameControls();
			GC.Enable();
			GC.InGame.Move.performed += Movement;
			GC.InGame.Move.canceled  += Movement;
			RB                       =  GetComponent<Rigidbody>();
			camera                   =  GetComponentInChildren<Camera>();
			camOffset                =  Vector3.Distance(camera.transform.position, gameObject.transform.position);
		}

		void Movement(InputAction.CallbackContext context)
		{
			//WSAD For moving on axis'

			direction = context.ReadValue<Vector2>();
			direction = new Vector3(direction.x, 0, direction.y);
		}

		private void Update()
		{
			//AirSpeed control (Check for ground and set speed to airSpeed [Slower])

			//Do the stuff here
			RB.AddForce(direction * speed);
		}

		private void FixedUpdate()
		{
		}

		private void OnDestroy()
		{
			GC.InGame.Move.performed -= Movement;
			GC.InGame.Move.canceled  -= Movement;
		}
	}
}