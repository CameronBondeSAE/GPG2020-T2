using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace alexM
{
	public class PlayerControllerTopDown : MonoBehaviour
	{
		public  float        speed;
		public Vector3 direction;
		private GameControls GC;
		private Rigidbody    RB;


		private void Awake()
		{
			GC = new GameControls();
			GC.Enable();
			GC.InGame.Move.performed += Movement;
			GC.InGame.Move.canceled += Movement;
			RB                     =  GetComponent<Rigidbody>();
		}

		void Movement(InputAction.CallbackContext context)
		{
			//WSAD For moving on axis'

			direction = context.ReadValue<Vector2>();
			direction = new Vector3(direction.x, 0, direction.y);


			// if (context.phase == InputActionPhase.Performed)
			// {
			// 	direction = context.ReadValue<Vector3>();
			// 	//Debug.Log("HOLDING KEY!");
			// }
			//
			// if (context.phase == InputActionPhase.Canceled)
			// {
			// 	direction = context.ReadValue<Vector3>();
			// 	Debug.Log("LET GO OF KEY!");
			// }
			//
			//Vector2 inputVal = context.ReadValue<Vector2>();
			//RB.velocity = new Vector3((inputVal.x * speed) * Time.deltaTime, 0, (inputVal.y * speed) * Time.deltaTime);
		}

		private void Update()
		{
			//AirSpeed control (Check for ground and set speed to airSpeed [Slower])
			
			//Do the stuff here
			RB.AddForce(direction * speed);
		}
	}
}