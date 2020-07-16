using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Student_workspace.Dylan.Scripts
{
    public class MouseLook : MonoBehaviour
    {
        private PlayerControl controls;
        private Vector2 look;
        private float xRotation;

        [Header("Mouse Settings")]
        [SerializeField] private float mouseSensitivity = 100f;
        [SerializeField] private Transform playerBody;
        [SerializeField] private float minLookAngle = -80f;
        [SerializeField] private float maxLookAngle = 80f;

        private void Awake()
        {
            controls = new PlayerControl();
            Cursor.lockState = CursorLockMode.Locked;

            if (playerBody == null)
            {
                playerBody = transform.parent;
            }
        }

        private void Update()
        {
            look = controls.Player.MouseLook.ReadValue<Vector2>();

            var MouseX = look.x * mouseSensitivity * Time.deltaTime;
            var MouseY = look.y * mouseSensitivity * Time.deltaTime;

            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, minLookAngle, maxLookAngle);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * MouseX);
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }
        
    }
}
