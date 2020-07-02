using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Main
{
	public class Player : MonoBehaviour
	{
		public float speed = 10f;
		// Start is called before the first frame update
		void Start()
		{
			GameControls gameControls = new GameControls();
			gameControls.Enable();
			gameControls.InGame.Move.performed += MoveOnperformed;
		}

		private void MoveOnperformed(InputAction.CallbackContext obj)
		{
			Vector2 readValue = obj.ReadValue<Vector2>();
			GetComponent<Rigidbody>().velocity = new Vector3(readValue.x*speed, 0, readValue.y*speed);
		}

		// Update is called once per frame
		void Update()
		{
		}
	}
}