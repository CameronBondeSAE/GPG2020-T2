using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace alexM
{
	public class PlayerController : MonoBehaviour
	{
		public  bool         cursorLocked;
		public  float        sensitivity;
		private float        _xRot,     _yRot; //_mouseX, _mouseY;
		public  Transform    neckJoint, body;
		public  GameControls gc;
		private Vector2      mousePosition;
		public  float        maxAngle = 80;

		private void Awake()
		{
			mouseLock();
			gc = new GameControls();
			gc.InGame.Enable();
		}

		void MouseLook()
		{
			mousePosition.x = (InputSystem.GetDevice<Mouse>().delta.x.ReadValue() * sensitivity) * Time.deltaTime;
			mousePosition.y = (InputSystem.GetDevice<Mouse>().delta.y.ReadValue() * sensitivity) * Time.deltaTime;
			
			_yRot = mousePosition.x;

			Quaternion yQuat = Quaternion.AngleAxis(mousePosition.y, -Vector3.right).normalized;
			Quaternion temp  = neckJoint.rotation * yQuat;
			
			if (Quaternion.Angle(body.rotation, temp) < maxAngle)
			{
				neckJoint.rotation = temp;
			}
			
			body.Rotate(0, _yRot, 0);

		}

		void mouseLock()
		{
			if (cursorLocked)
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
			else
			{
				Cursor.lockState = CursorLockMode.None;
			}
		}

		private void FixedUpdate()
		{
			MouseLook();
		}
	}
}