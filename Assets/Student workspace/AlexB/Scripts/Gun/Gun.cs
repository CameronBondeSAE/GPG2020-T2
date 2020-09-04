using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AJ
{
	public class Gun : NetworkBehaviour
	{
		public GameObject bulletPrefab;

		public Transform bulletSpawn;

		// private GameControls gameControls;
		//public Player player;
		public ColourChanger colourChanger;
		public bool          debugInput = false;

		// void Awake()
		// {
		//     if(isServer)
		//     {
		//         if (debugInput)
		//         {
		//             gameControls = new GameControls();
		//             gameControls.Enable();
		//             gameControls.InGame.Fire.performed += Shoot;
		//         }
		//     }
		//
		// }

		[Command(ignoreAuthority = true)]
		public void CmdShoot()
		{
			// RpcShoot();
			
			GameObject bullet = Instantiate(this.bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			Debug.Log("I Shot");
			// TODO, use ColourChanger for this (so we don't have to fix things in 50 different spots)
			bullet.GetComponent<ColourChanger>().ChangeTo(colourChanger.currentColor);

			NetworkServer.Spawn(bullet);
		}

		// [ClientRpc]
		// public void RpcShoot()
		// {
		// 	Shoot();
		// }

		public void Shoot()
		{
			GameObject bullet = Instantiate(this.bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			Debug.Log("I Shot");
			// TODO, use ColourChanger for this (so we don't have to fix things in 50 different spots)
			bullet.GetComponent<ColourChanger>().ChangeTo(colourChanger.currentColor);

			NetworkServer.Spawn(bullet);
		}
	}
}