using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AJ;
using DG.Tweening;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEditor.Build.CacheServer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using NetworkBehaviour = Mirror.NetworkBehaviour;
using NetworkIdentity = Mirror.NetworkIdentity;

namespace alexM
{
	public class PlayerControllerTopDown : NetworkBehaviour, IOwnable, IPossesable
	{
		public  float             speed, jumpForce;
		public  Vector3           direction;
		public  Rigidbody         RB;
		public  GameObject        bottom, neck;
		private Camera_Controller cameraController;

		[SerializeField]
		bool _isGrounded;

		public NetworkIdentity Owner
		{
			get => _owner;
			set => _owner = value;
		}
		[SerializeField]
		private NetworkIdentity _owner;

		public NetworkGamePlayer posessor { get; set; }

		private void Start()
		{
			if (isServer)
			{
				RpcSyncOwner(Owner);
				RpcSyncPosessor(Owner);
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

			posessor = n.gameObject.GetComponent<NetworkGamePlayer>();
			
			// Setting itself as the possessable in the game player may not be a good idea.
			//n.gameObject.GetComponent<NetworkGamePlayer>().possesable = ((IPossesable) this);
		}
		#endregion
		
		public void Movement(Vector2 dir)
		{
			direction = dir;
			direction = new Vector3(direction.x, 0, direction.y);
		}

		 public void Jump()
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



		public void Aiming(Vector2 pos)
		{
			Ray        ray = cameraController.cam.ScreenPointToRay(pos);
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
		public void Fire()
		{
		
		}
		public void Interact()
		{
			
		}
		public void Action1()
		{
			
		}
		public void Action2()
		{
		
		}
		public void Action3()
		{
			
		}
	}
}