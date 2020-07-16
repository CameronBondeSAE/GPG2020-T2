using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace alexM
{
	public class PlayerControllerTopDown : NetworkBehaviour
	{
		public  float        speed;
		public  Vector3      direction;
		private GameControls GC;
		private Rigidbody    RB;

		private void Awake()
		{
			GC = new GameControls();
			GC.Enable();
			GC.InGame.Move.performed += Movement;
			GC.InGame.Move.canceled  += Movement;
			RB                       =  GetComponent<Rigidbody>();
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.GetComponent<HealthComponent>())
			{
				other.gameObject.GetComponent<HealthComponent>()?.Death();
			}
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
		

		private void OnDestroy()
		{
			GC.InGame.Move.performed -= Movement;
			GC.InGame.Move.canceled  -= Movement;
		}
	}
}