using System;
using UnityEngine;

namespace Student_workspace.Dylan.Scripts
{
    public class PlayerMovementRB : MonoBehaviour
    {
        private PlayerControl controls;
        private Vector2 move;
        [SerializeField] private Rigidbody rb;
        

        [Header("Movement Settings")]
        public float moveSpeed;
        
        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }

        private void Awake()
        {
            controls = new PlayerControl();
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            move = controls.Player.Movement.ReadValue<Vector2>();
            Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
            
            // rb.AddForce(movement * (moveSpeed * Time.deltaTime));
            rb.AddForce(movement.normalized * moveSpeed);
        }
    }
}
