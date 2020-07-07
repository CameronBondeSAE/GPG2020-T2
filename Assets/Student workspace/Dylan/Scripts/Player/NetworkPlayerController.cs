using System;
using Mirror;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

namespace Student_workspace.Dylan.Scripts.Player
{
    /// <summary>
    /// everything to do with the player should got here depending on what it is
    /// this has nothing to do with the lobby player this is for in-game movement
    /// </summary>
    
    public class NetworkPlayerController : NetworkBehaviour
    {
        public float moveSpeed = 5f;
        public CharacterController controller = null;

        private Vector2 previousInput;

        private PlayerControl controls;

        private PlayerControl Controls
        {
            get
            {
                if (controls != null)
                {
                    return controls;
                }

                return controls = new PlayerControl();
            }
        }

        

        public override void OnStartAuthority()
        {
            enabled = true;

            Controls.Player.Movement.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
            Controls.Player.Movement.canceled += ctx => ResetMovement();
        }

        [ClientCallback]
        private void OnEnable()
        {
            Controls.Enable();
        }

        [ClientCallback]
        private void OnDisable()
        {
            Controls.Disable();
        }

        [ClientCallback]
        private void Update()
        {
            Move();
        }

        [Client]
        private void Move()
        {
            Vector3 right = controller.transform.right;
            Vector3 forward = controller.transform.forward;
            right.y = 0f;
            forward.y = 0f;

            Vector3 movement = right.normalized * previousInput.x + forward.normalized * previousInput.y;

            controller.Move(movement * (moveSpeed * Time.deltaTime));
        }
        
        [Client]
        private void SetMovement(Vector2 movement)
        {
            previousInput = movement;
        }

        [Client]
        private void ResetMovement()
        {
            previousInput = Vector2.zero;
        }
    }
}