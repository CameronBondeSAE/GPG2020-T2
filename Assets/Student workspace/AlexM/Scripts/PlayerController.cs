using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace alexM
{
    public class PlayerController : MonoBehaviour
    {
        public float sensitivity;
        private float _xRot, _yRot, _mouseX, _mouseY;
        public Transform neckJoint;
        public GameControls gc;

        private void Awake()
        {
             gc = new GameControls();
             gc.InGame.Enable();
        }

        void MouseLook()
        {
             _mouseX += (InputSystem.GetDevice<Mouse>().delta.x.ReadValue() * sensitivity ) * Time.deltaTime;
             _mouseY += (InputSystem.GetDevice<Mouse>().delta.y.ReadValue() * sensitivity ) * Time.deltaTime;

            _xRot = _mouseY;
            _xRot = Mathf.Clamp(_xRot, -50, 50);
            
             _yRot = _mouseX;
             _yRot = Mathf.Clamp(_yRot, -50, 50);
            
            //neckJoint.Rotate(Vector3.up * mouseX);
            neckJoint.transform.rotation = Quaternion.Euler(-_xRot, _yRot ,0);

            Debug.Log("x: " + _mouseX + " y: " + _mouseY);

            // xRot -= mouseY;
            // xRot = Mathf.Clamp(xRot, -90, 90);
            //
            // neckJoint.Rotate(Vector3.up * xRot);

        }


        private void FixedUpdate()
        {
            MouseLook();
        }
    }
}
