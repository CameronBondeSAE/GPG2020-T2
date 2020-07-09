using System.Collections;
using System.Collections.Generic;
using Cam;
using Mirror;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Main
{
	public class Player : CharacterBase
	{
		public GameObject target;
		public float      speed = 10f;
		public Vector3    direction;

		public SceneAsset anything;

		// Start is called before the first frame update
		void Start()
		{
			Debug.Log(anything.name);
			
			GameControls gameControls = new GameControls();
			gameControls.Enable();
			gameControls.InGame.Move.performed += MoveOnperformed;
			gameControls.InGame.Move.canceled  += MoveOncanceled;
			// gameControls.InGame.Look.performed += context => Debug.Log(context.ReadValue<Vector2>());


			KillThingInstantly();
		}

		private void MoveOncanceled(InputAction.CallbackContext obj)
		{
		}

		private void MoveOnperformed(InputAction.CallbackContext context)
		{
			Debug.Log("Performed");
			// if (context.phase == InputActionPhase.Performed)
			// {
			direction = context.ReadValue<Vector2>();
			// }
			// if (context.phase == InputActionPhase.Canceled)
			// {
			// 	direction = context.ReadValue<Vector2>();
			// }
		}

		// Update is called once per frame
		void Update()
		{
			GetComponent<Rigidbody>().velocity = new Vector3(direction.x, 0, direction.y) * speed;
		}

		public void KillThingInstantly()
		{
			// Check if target is dead
			// if (target.GetComponent<Health>().health > 0)
			// {
				// target.GetComponent<Health>().health = -1000000;
				// target.GetComponent<Health>().Die();
			// }
		}

		public void Die()
		{
		}
	}
}