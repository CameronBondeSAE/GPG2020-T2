using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using DG.Tweening;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

namespace alexM
{
	public class PlayerControllerTopDown : NetworkBehaviour
	{
		public float speed, jumpForce;
		public Vector3 direction;
		private GameControls GC;
		private Rigidbody RB;
		private GameObject bottom, neck;
		private Camera_Controller cameraController;
		[SerializeField] bool _isGrounded;

		private void Awake()
		{
			GC = new GameControls();
			GC.Enable();
			GC.InGame.Move.performed += Movement;
			GC.InGame.Move.canceled += Movement;
			GC.InGame.Jump.performed += Jump;
			GC.InGame.Jump.canceled += Jump;
			// GC.InGame.Fire.performed += LookAtMouse;
			// GC.InGame.Fire.canceled  += LookAtMouse;
			GC.InGame.MousePosition.performed += LookAtMouse;
			//GC.InGame.MousePosition.canceled += LookAtMouse;
			RB = GetComponent<Rigidbody>();
			bottom = GameObject.Find("Base");
			neck = GameObject.Find("Neck");
			cameraController = GetComponent<Camera_Controller>();
		}

		private void OnCollisionEnter(Collision other)
		{
			// if (other.gameObject.GetComponent<HealthComponent>())
			// {
			// 	other.gameObject.GetComponent<HealthComponent>().Death();
			// }
		}

		void Movement(InputAction.CallbackContext context)
		{
			direction = context.ReadValue<Vector2>();
			direction = new Vector3(direction.x, 0, direction.y);
		}

		void Jump(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				if (GroundCheck())
				{
					RB.AddForce(direction.x, jumpForce, direction.z);
				}
				else
				{
					Debug.Log("Not Grounded, Can't jump!");
				}
			}
		}

		bool GroundCheck()
		{
			int layerMask = 1 << 12;
			layerMask = ~layerMask;


			Vector3 down = bottom.transform.TransformDirection(Vector3.down);
			RaycastHit hit;

			//AirSpeed control (Check for ground and set speed to airSpeed [Slower])
			if (Physics.Raycast(bottom.transform.position, down, out hit, 0.9f, layerMask))
			{
				Debug.DrawRay(bottom.transform.position, down * hit.distance, Color.yellow);
				//Debug.Log("dist: " + hit.distance);
				_isGrounded = true;
				return true;
			}
			else
			{
				_isGrounded = false;
				return false;
			}
		}

		void LookAtMouse(InputAction.CallbackContext context)
		{
			Ray ray = cameraController.cam.ScreenPointToRay(context
				.ReadValue<Vector2>());
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				neck.transform.LookAt(new Vector3(hit.point.x,neck.transform.position.y, hit.point.z));
				
				//Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 0.1f);
			}
		}

		private void FixedUpdate()
		{
			//Do the stuff here
			GroundCheck();

			if (!_isGrounded)
			{
				RB.AddForce((direction * speed) / 3);
			}
			else
			{
				RB.AddForce(direction * speed);
			}


			// if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 5f))
			// {
			// 	Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
			// 	//Debug.Log(hit.transform.name + " Was hit");
			// }
		}


		private void OnDestroy()
		{
			GC.InGame.Move.performed -= Movement;
			GC.InGame.Move.canceled -= Movement;
			GC.InGame.Jump.performed -= Jump;
			GC.InGame.Jump.canceled -= Jump;
			// GC.InGame.Fire.performed -= LookAtMouse;
			// GC.InGame.Fire.canceled  -= LookAtMouse;
			GC.InGame.MousePosition.performed -= LookAtMouse;
			//GC.InGame.MousePosition.canceled += LookAtMouse;
		}
	}
}