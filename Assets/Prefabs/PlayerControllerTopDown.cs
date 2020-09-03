﻿using System.Collections;
using System.Collections.Generic;
using AJ;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using UnityEngine.InputSystem;
using NetworkBehaviour = Mirror.NetworkBehaviour;
using NetworkIdentity = Mirror.NetworkIdentity;

namespace alexM
{
	public class PlayerControllerTopDown : NetworkBehaviour, IOwnable, IPossessable
	{
		public  float             moveForce, jumpForce;
		public  float             maxSpeed;
		public  Vector3           direction;
		public  Rigidbody         RB;
		public  GameObject        bottom, neck;
		private Camera_Controller cameraController;
		public float GroundCheckRadius = 0.2f;
		public Gun gun;
		[SerializeField] private LayerMask groundableLayers;
		[SerializeField]
		bool _isGrounded;

		public NetworkIdentity Owner
		{
			get => _owner;
			set => _owner = value;
		}

		[SerializeField]
		private NetworkIdentity _owner;

		public NetworkGamePlayer possessor { get; set; }


		public override void OnStartServer()
		{
			base.OnStartServer();

			Debug.Log("Mine = " + netIdentity.netId + "Owner = " + netIdentity.connectionToClient.identity.netId);
			if (isServer)
			{

				StartCoroutine(ResyncCorountine());


			}
		}

		IEnumerator ResyncCorountine()
		{
			yield return new WaitForSeconds(1);
			
			if (isServer)
			{
				RpcSyncOwner(Owner);
				RpcSyncPosessor(Owner);
				
				
			}
		}


		private void Start()
		{
			//DontDestroyOnLoad(gameObject);

			cameraController = GetComponent<Camera_Controller>();


			if (isServer)
			{
				RpcSyncOwner(Owner);
				RpcSyncPosessor(Owner);
			}
		}

		private void Update()
		{
			if (InputSystem.GetDevice<Keyboard>().rKey.wasPressedThisFrame)
			{
				if (isServer)
				{
					RpcSyncOwner(Owner);
					RpcSyncPosessor(Owner);
				}
			}
		}

		#region PlayerNetworkSetup

		private void CheckIfClient()
		{
			if (isClient)
			{
				if (Owner != null)
				{
					if (Owner.isLocalPlayer)
					{
						Debug.Log(this + " Is local.");

						cameraController.Setup();
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

		[ClientRpc]
		public void RpcSyncPosessor(NetworkIdentity n)
		{
			possessor = n.gameObject.GetComponent<NetworkGamePlayer>();

			// Setting itself as the possessable in the game player may not be a good idea.
			n.gameObject.GetComponent<NetworkGamePlayer>().possessable = ((IPossessable) this);
		}

		#endregion

		public void Movement(Vector2 dir, InputAction.CallbackContext ctx)
		{
			direction = dir;
			direction = new Vector3(direction.x, 0, direction.y);
		}
		
		private void FixedUpdate()
		{
			//Do the stuff here
			GroundCheck();
			if (!_isGrounded)
			{
				 RB.AddForce((direction * moveForce) / 10);
			}
			else
			{
			
				
				//new method of max speed,  Addforce, if it excedes max speed after adding, Add the inverse to undo the add. A little hacky but far simpler than hand predicting the new velocity because of drag and friction.
				
				RB.AddForce(direction * moveForce);

				if (RB.velocity.magnitude > maxSpeed) 
				{
					RB.AddForce(-direction * moveForce);
				}


				
				
				
				//Old Method of max speed, gets in the way of other objects effecting the rigidbody.
				
				
				/*
				// Velocity cap
				float oldYVel = RB.velocity.y; // Let's keep our Y speed, for jumping etc
				RB.velocity = Vector3.ClampMagnitude(RB.velocity, maxSpeed);
				RB.velocity = new Vector3(RB.velocity.x, oldYVel, RB.velocity.z);
				*/
				
				
				
				
			}


			// if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 5f))
			// {
			// 	Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
			// 	//Debug.Log(hit.transform.name + " Was hit");
			// }
		}

		public void Jump(InputAction.CallbackContext ctx)
		{
			if (GroundCheck())
			{
				RB.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
			}
			else
			{
				Debug.Log("Not Grounded, Can't jump!");
			}
		}

		bool GroundCheck()
		{
			/*
			int layerMask = 1 << 12;
			layerMask = ~layerMask;
			*/


			Vector3    down = bottom.transform.TransformDirection(Vector3.down);
			RaycastHit hit;

			//AirSpeed control (Check for ground and set speed to airSpeed [Slower])
			/*if (Physics.Raycast(bottom.transform.position, down, out hit, 1f, layerMask))
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
			}*/
			
			
			
			if (Physics.SphereCast(bottom.transform.position, GroundCheckRadius, down, out hit, 0.65f, groundableLayers))
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




		public void Aiming(Vector2 pos, InputAction.CallbackContext ctx)
		{
			if (cameraController != null)
			{
				if (cameraController.cam != null)
				{
					Ray        ray = cameraController.cam.ScreenPointToRay(pos);
					RaycastHit hit;

					if (Physics.Raycast(ray, out hit))
					{
						neck.transform.LookAt(new Vector3(hit.point.x, neck.transform.position.y, hit.point.z));

						//Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 0.1f);
					}
				}
				else
				{
					Debug.Log("No Camera set");
				}
			}
			else
			{
				Debug.Log("noCamController");
			}
		}

		public void Fire(InputAction.CallbackContext ctx)
		{
			if (!(gun is null)) gun.Shoot(ctx);
		}

		public void Interact(InputAction.CallbackContext ctx)
		{
		}

		public void Action1(InputAction.CallbackContext ctx)
		{
		}

		public void Action2(InputAction.CallbackContext ctx)
		{
		}

		public void Action3(InputAction.CallbackContext ctx)
		{
		}
	}
}