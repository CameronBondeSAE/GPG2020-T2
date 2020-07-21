using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace alexM
{
    public class PlayerControllerTopDown : MonoBehaviour
    {
        public float speed, jumpForce;
        public Vector3 direction;
        private GameControls GC;
        private Rigidbody RB;
        private GameObject bottom;
        [SerializeField] bool _isGrounded;

        private void Awake()
        {
            GC = new GameControls();
            GC.Enable();
            GC.InGame.Move.performed += Movement;
            GC.InGame.Move.canceled += Movement;
            GC.InGame.Jump.performed += Jump;
            GC.InGame.Jump.canceled += Jump;
            RB = GetComponent<Rigidbody>();
            bottom = GameObject.Find("Base");
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<HealthComponent>())
            {
                other.gameObject.GetComponent<HealthComponent>().Death();
            }
        }

        void Movement(InputAction.CallbackContext context)
        {
            direction = context.ReadValue<Vector2>();
            direction = new Vector3(direction.x, 0, direction.y);
        }

        void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (GroundCheck())
                {
                    RB.AddForce(direction.x, jumpForce, direction.z);
                }
                else
                {
                    Debug.Log("Not Grounded, Can't jump!");
                }
            }
        }

        bool GroundCheck()
        {
            int layerMask = 1 << 10;
            layerMask = ~layerMask;

            //GameObject bottom;
            //bottom = GameObject.Find("Base");
            Vector3 down = bottom.transform.TransformDirection(Vector3.down);
            RaycastHit hit;
            //AirSpeed control (Check for ground and set speed to airSpeed [Slower])
            if (Physics.Raycast(bottom.transform.position, down, out hit, 0.8f, layerMask))
            {
                Debug.DrawRay(bottom.transform.position, down * hit.distance, Color.yellow);
                _isGrounded = true;
                return true;
                //Debug.Log("Hit: " + hit.transform.name.ToString() + ", Dist: " + hit.distance.ToString());
            }
            else
            {
                _isGrounded = false;
                return false;
            }
        }

        private void FixedUpdate()
        {
            // if (GroundCheck())
            // {
            // 	Debug.Log("Grounded!!");
            // }

            //Do the stuff here
            GroundCheck();

            if (!_isGrounded)
            {
                RB.AddForce((direction * speed) / 3); 
            }
            else
            {
                RB.AddForce(direction * speed);
            }
            

            // if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 5f))
            // {
            // 	Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
            // 	//Debug.Log(hit.transform.name + " Was hit");
            // }
        }


        private void OnDestroy()
        {
            GC.InGame.Move.performed -= Movement;
            GC.InGame.Move.canceled -= Movement;
            GC.InGame.Jump.performed -= Jump;
            GC.InGame.Jump.canceled -= Jump;
        }
    }
}