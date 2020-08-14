using System;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Student_workspace.Cam
{
	public class Tests : MonoBehaviour
	{
		public float speedScale;

		[ShowInInspector]
		private float speed;

		public float Speed
		{
			get
			{
				
				return speed;
			}
		}

		public LayerMask lm;

		private void Start()
		{
			
			
			GameObject go = new GameObject();

			go.AddComponent<Rigidbody>();
			go.AddComponent<Collider>();


			Debug.Log(IsInLayerMask(gameObject.layer, lm));
			
			GameControls gameControls = new GameControls();
			gameControls.InGame.Fire.performed += MouseLookOnperformed;
			gameControls.InMenu.Newaction.performed += NewactionOnperformed;

			gameControls.InGame.Enable();
			gameControls.InMenu.Disable();
		}

		private void NewactionOnperformed(InputAction.CallbackContext obj)
		{
		}

		private void MouseLookOnperformed(InputAction.CallbackContext obj)
		{
		}

		public bool IsInLayerMask(int layer, LayerMask layermask)
		{
			return layermask == (layermask | (1 << layer));
		}
	}
}