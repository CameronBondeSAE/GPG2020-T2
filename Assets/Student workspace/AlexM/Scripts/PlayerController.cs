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
			gc = new GameControls();
			gc.InGame.Enable();
		}

		void MouseLook()
		{
			mousePosition.x = (InputSystem.GetDevice<Mouse>().delta.x.ReadValue() * sensitivity) * Time.deltaTime;
			mousePosition.y = (InputSystem.GetDevice<Mouse>().delta.y.ReadValue() * sensitivity) * Time.deltaTime;

			//_xRot = -mousePosition.y;
			//_xRot =  Mathf.Clamp(_xRot, -50, 50);

			_yRot = mousePosition.x;
			//_yRot =  Mathf.Clamp(_yRot, -50, 50);

			Quaternion yQuat = Quaternion.AngleAxis(mousePosition.y, -Vector3.right).normalized;
			Quaternion temp  = neckJoint.rotation * yQuat;
			
			if (Quaternion.Angle(body.rotation, temp) < maxAngle)
			{
				neckJoint.rotation = temp;
			}
			//neckJoint.Rotate(-_xRot,0,0);


			body.Rotate(0, _yRot, 0);
			// _mouseX += (InputSystem.GetDevice<Mouse>().delta.x.ReadValue() * sensitivity) * Time.deltaTime;
			// _mouseY += (InputSystem.GetDevice<Mouse>().delta.y.ReadValue() * sensitivity) * Time.deltaTime;
			// _xRot = _mouseY;
			// _xRot = Mathf.Clamp(_xRot, -50, 50);
			//
			// _yRot = _mouseX;
			// _yRot = Mathf.Clamp(_yRot, -50, 50);


			//Debug.Log("x: " + _mouseX + " y: " + _mouseY);
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
			mouseLock();
		}
	}
}