using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AJ;
using DG.Tweening;
using Mirror;
using UnityEditor.Build.CacheServer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using NetworkBehaviour = Mirror.NetworkBehaviour;
using NetworkIdentity = Mirror.NetworkIdentity;

namespace alexM
{
	public class PlayerControllerTopDown : NetworkBehaviour, IOwnable
	{
		public  float             speed, jumpForce;
		public  Vector3           direction;
		public  Rigidbody         RB;
		public  GameObject        bottom, neck;
		private Camera_Controller cameraController;

		[SerializeField]
		bool _isGrounded;

		private GameControls gameControls;


		public NetworkIdentity Owner
		{
			get => _owner;
			set => _owner = value;
		}

		[SerializeField]
		private NetworkIdentity _owner;

		private void Start()
		{
			if (isServer)
			{
				RpcSyncOwner(Owner);
			}
		}

		#region PlayerNetworkSetup

		private void CheckIfClient()
		{
			if (isClient)
			{
				cameraController = GetComponent<Camera_Controller>();
				if (Owner != null)
				{
					if (Owner.isLocalPlayer)
					{
						Debug.Log(this + " Is local.");

						cameraController.Setup();
						AssignControl();
					}

					// else
					// {
					// 	Debug.Log(this + " is not local.");
					// 	cameraController.cam.gameObject.SetActive(false);
					// 	cameraController.enabled = false;
					// }
				}
				else
				{
					Debug.LogWarning("Owner Is NULL");
				}
			}
		}

		[ClientRpc]
		public void RpcSyncOwner(NetworkIdentity n)
		{
			Owner = n;
			CheckIfClient();
		}

		void AssignControl()
		{
			gameControls = new GameControls();
			gameControls.Enable();
			gameControls.InGame.Move.performed          += Movement;
			gameControls.InGame.Move.canceled           += Movement;
			gameControls.InGame.Jump.performed          += Jump;
			gameControls.InGame.Jump.canceled           += Jump;
			gameControls.InGame.MousePosition.performed += LookAtMouse;
		}

		#endregion


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


			Vector3    down = bottom.transform.TransformDirection(Vector3.down);
			RaycastHit hit;

			//AirSpeed control (Check for ground and set speed to airSpeed [Slower])
			if (Physics.Raycast(bottom.transform.position, down, out hit, 1f, layerMask))
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
			Ray        ray = cameraController.cam.ScreenPointToRay(context.ReadValue<Vector2>());
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				neck.transform.LookAt(new Vector3(hit.point.x, neck.transform.position.y, hit.point.z));

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
			if (isClient)
			{
				if (Owner != null)
				{
					if (Owner.isLocalPlayer)
					{
						gameControls.InGame.Move.performed -= Movement;
						gameControls.InGame.Move.canceled  -= Movement;
						gameControls.InGame.Jump.performed -= Jump;
						gameControls.InGame.Jump.canceled  -= Jump;
						// GC.InGame.Fire.performed -= LookAtMouse;
						// GC.InGame.Fire.canceled  -= LookAtMouse;
						gameControls.InGame.MousePosition.performed -= LookAtMouse;
						//GC.InGame.MousePosition.canceled += LookAtMouse;
					}
				}
			}
		}
	}
}