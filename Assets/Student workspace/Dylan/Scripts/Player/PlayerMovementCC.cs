using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Student_workspace.Dylan.Scripts
{
    public class PlayerMovementCC : MonoBehaviour
    {
        private PlayerControl controls;

        [SerializeField] private float movementSpeed;
        private Vector2 move;

        private CharacterController characterController;
        private void Awake()
        {
            controls= new PlayerControl();
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            move = controls.Player.Movement.ReadValue<Vector2>();

            Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);

            characterController.Move(movement * movementSpeed * Time.deltaTime);
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
