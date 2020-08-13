using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AJ
{
	public class CamGun : MonoBehaviour
	{
		public  GameObject   bullet;
		public  Transform    bulletSpawn;
		private GameControls gameControls;

		public event Action shootEvent;

		void Awake()
		{
			gameControls = new GameControls();
			gameControls.Enable();
			gameControls.InGame.Fire.performed += Shoot;
		}

		void Shoot(InputAction.CallbackContext context)
		{
			Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
			Debug.Log("I Shot");
			shootEvent?.Invoke();
		}
	}
}